using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ApiForAndroid.Entity;

namespace ApiForAndroid.Models
{
    public class ResponseAssets
    {
        public ResponseAssets(Assets assets)
        {
            ID = assets.ID;
            AssetSN = assets.AssetSN;
            AssetName = assets.AssetName;
            DepartmentLocationID = assets.DepartmentLocationID;
            EmployeeID = assets.EmployeeID;
            AssetGroupID = assets.AssetGroupID;
            Description = assets.Description;
            WarrantyDate = assets.WarrantyDate;
            Assetphotos = assets.AssetPhotos.ToList().FirstOrDefault()?.AssetPhoto;

        }
        public long ID { get; set; }
        public string AssetSN { get; set; }
        public string AssetName { get; set; }
        public long DepartmentLocationID { get; set; }
        public long EmployeeID { get; set; }
        public long AssetGroupID { get; set; }
        public string Description { get; set; }
        public Nullable<System.DateTime> WarrantyDate { get; set; }
        public byte[] Assetphotos { get; set; }
    }
}