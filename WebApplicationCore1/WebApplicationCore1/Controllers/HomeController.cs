﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DapperAdapter;
using DataModels.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplicationCore1.ViewModels;

namespace WebApplicationCore1.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDapperService _dapperService;

        public HomeController(IDapperService dapperService)
        {
            _dapperService = dapperService;
        }

        [Route("RegPoz")]
        public IActionResult RegPoz(/*[FromQuery] int regid*/)
        {
            int regid = 1;


            var regpoz = new RegPozViewModel() { FormId = regid };

            var data = _dapperService.SelectList<EditableFeatureView, object>("[dbo].[EditableFeature_GetFeaturesByFormId]", new { formId = regid });

            if (data != null && data.Count() > 0)
            {
                regpoz.FeatureList = data.GroupBy(x => new { x.FormId, x.FeatureId, x.FeatureName, x.FeatureClassifierId })
                    .Select(x => new FeatureViewModel
                    {
                        FeatureId = x.Key.FeatureId,
                        FeatureName = x.Key.FeatureName,
                        FeatureValue = x.Key.FeatureClassifierId,
                        FeatureValueName = x.Where(y => y.ClassifierId == x.Key.FeatureClassifierId).Select(y => y.ClassifierValue).FirstOrDefault(),
                        FeatureClassifier = x.Select(y => new Classifier
                        {
                            ClassifierTypeId = y.ClassifierTypeId,
                            Id = y.ClassifierId,
                            Value = y.ClassifierValue
                        }),
                        DropDownData = x.Select(y => new { Value = y.ClassifierId, Text = y.ClassifierValue })
                    })
                    .ToList();

                regpoz.DropDowns = _dapperService.SelectList<Classifier, object>("[dbo].[Classifier_GetAll]", null).Select(x => new DropDown { Text = x.Value, FeatureValue = x.Id}).ToList();
            }

			return View(regpoz);
        }

        //[HttpPost]
        //[Route("SaveChanges")]
        //public IActionResult SaveChanges(IFormCollection collection)
        //{         
        //    if (collection != null)
        //    {
        //        int id = collection
        //            .Where(x => x.Key == "formId")
        //            .Select(x => int.Parse(x.Value))
        //            .FirstOrDefault();

        //        var listFeatures = _dapperService
        //            .SelectList<Feature, object>("[dbo].[Feature_GetFeaturesByFormId]", new { formId = id })
        //            .ToList();

        //        if (listFeatures != null)
        //        {

        //            foreach (var item in collection)
        //            {
        //                if (!string.IsNullOrWhiteSpace(item.Value) && item.Key != "formId")
        //                {
        //                    var feature = listFeatures
        //                        .Where(x => x.Id == int.Parse(item.Key))
        //                        .FirstOrDefault();

        //                    feature.ClassifierId = int.Parse(item.Value);
        //                }
        //            }

        //            _dapperService.UpdateList<Feature>(listFeatures);
        //        }
        //    }

        //    return Redirect("RegPoz");
        //}



        [HttpPost]
        [Route("SaveChanges")]
        public IActionResult SaveChanges(IFormCollection collection)
        {
            if (collection != null)
            {
                foreach (var item in collection)
                {
                    if (!string.IsNullOrWhiteSpace(item.Value) && item.Key != "formId")
                    {
                        _dapperService.Update<Feature, object>(
                            "[dbo].[Feature_UpdateClassifierId]", 
                            new { featureId = int.Parse(item.Key), classifierId = int.Parse(item.Value) });
                    }
                }
            }

            return Redirect("RegPoz");
        }
    }
}
