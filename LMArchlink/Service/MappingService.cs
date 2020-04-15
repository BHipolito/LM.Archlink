using System;
using System.Collections.Generic;
using System.IO;
using LMArchlink.Models;
using Microsoft.AspNetCore.Http;
using OfficeOpenXml;

namespace LMArchlink.Service
{
    public class MappingService
    {
        public List<ArchlinkModel> MapFormService (IFormFile formFile)
        {
         
            var list = new List<ArchlinkModel>();

            using (var stream = new MemoryStream())
            {

                formFile.CopyTo(stream);

                using (var package = new ExcelPackage(stream))
                {
                    ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
                    var rowCount = worksheet.Dimension.Rows;

                    for (int row = 2; row <= rowCount; row++)
                    {
                        list.Add(new ArchlinkModel
                        {
                            accountNumber = worksheet.Cells[row, 1].Value.ToString().Trim(),
                            proposedPolicyEffectiveDate = worksheet.Cells[row, 2].Value.ToString().Trim(),
                            producerNumber = worksheet.Cells[row, 3].Value.ToString().Trim(),
                            producingBranch = worksheet.Cells[row, 4].Value.ToString().Trim(),
                            businessDivisionCode = worksheet.Cells[row, 5].Value.ToString().Trim(),
                            businessSubDivisionCode = worksheet.Cells[row, 6].Value.ToString().Trim(),
                            sectionCode = worksheet.Cells[row, 7].Value.ToString().Trim(),
                            underWriterUserName = worksheet.Cells[row, 8].Value.ToString().Trim(),
                            currency = worksheet.Cells[row, 9].Value.ToString().Trim(),
                            policyTermInMonths = Convert.ToInt32(worksheet.Cells[row, 10].Value),
                            placementBasis = worksheet.Cells[row, 11].Value.ToString().Trim(),
                            submissionType = worksheet.Cells[row, 14].Value.ToString().Trim(),
                            productFamilies = new List<productFamilies> 
                                { new productFamilies { 
                                    productFamilyCode = worksheet.Cells[row, 13].Value.ToString() 
                                }    
                            }
                        }); ;
                    }
                }
            }

            return list;
        }

    }
}
