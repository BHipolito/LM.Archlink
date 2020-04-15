using System.Collections.Generic;

namespace LMArchlink.Models
{
    public class ArchlinkModel
    {
            public string accountNumber { get; set; }
            public string proposedPolicyEffectiveDate { get; set; }
            public string producerNumber { get; set; }
            public string producingBranch { get; set; }
            public string businessDivisionCode { get; set; }
            public string businessSubDivisionCode { get; set; }
            public string sectionCode { get; set; }
            public string underWriterUserName { get; set; }
            public string currency { get; set; }
            public int policyTermInMonths { get; set; }
            public string placementBasis { get; set; }
            public List<productFamilies> productFamilies { get; set; }
            public string submissionType { get; set; }
    }

    public class productFamilies
    {
        public string productFamilyCode { get; set; }
    }
}
