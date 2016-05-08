using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Trial.Models
{
    public class EstimationHeaderTranViewModel
    {
        public EstimationHeaderTranViewModel()
        {
            EstimationBodyTrans = new List<EstimationBodyTranViewModel>
            {
                new EstimationBodyTranViewModel {Gyo_No = 1},
                new EstimationBodyTranViewModel {Gyo_No = 2},
                new EstimationBodyTranViewModel {Gyo_No = 3},
                new EstimationBodyTranViewModel {Gyo_No = 4},
                new EstimationBodyTranViewModel {Gyo_No = 5},
                new EstimationBodyTranViewModel {Gyo_No = 6}
            };
        }

        [Display(Name = "見積No.")]
        public decimal? Mitsu_No { get; set; }

        [Required(ErrorMessage = "見積日を入力してください")]
        [Display(Name = "見積日")]
        public DateTime? Mitsu_Date { get; set; }

        [Required(ErrorMessage = "担当者を選択してください")]
        [Display(Name = "担当者")]
        public string Tantosha_Cd { get; set; }

        [Required(ErrorMessage = "得意先を入力してください")]
        [Display(Name = "得意先")]
        //[Remote("ValidateTokui", "Estimation", ErrorMessage = "得意先マスタが見つかりません")]
        public string Tokui_Cd { get; set; }

        [Display(Name = "得意先.Name")]
        public string Tokui_Name { get; set; }

        [Display(Name = "要件")]
        public string Yoken { get; set; }

        [Required]
        [Display(Name = "支払方法")]
        public string Shiharai_Cd { get; set; }

        [Required]
        [Display(Name = "有効期限")]
        public string Yuko_kigen_Cd { get; set; }

      //  [Remote("ValidateEstimationBodyTrans", "Estimation", ErrorMessage = "商品明細を入力してください")]
        [Display(Name = "商品.List")]
        public IEnumerable<EstimationBodyTranViewModel > EstimationBodyTrans { get; set; }
    }

    public class EstimationBodyTranViewModel
    {
        [Display(Name = "見積No.")]
        public decimal? Mitsu_No { get; set; }

        [Display(Name = "行")]
        public int? Gyo_No { get; set; } 

        [Display(Name = "商品")]
       // [Remote("ValidateShohin", "Estimation", ErrorMessage = "商品マスタが見つかりません")]
        public string Shohin_Cd { get; set; }

        [Display(Name = "商品.Name")]
        public string Shohin_Name { get; set; }

        [Display(Name = "数量")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal? Suryo { get; set; }

        [Display(Name = "単位")]
        public string Tani { get; set; }

        [Display(Name = "単価")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal? Tanka { get; set; }

        [Display(Name = "金額")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:c}")]
        public decimal? Kingaku { get; set; }
    }

    public class CustomerMasterViewModel
    {
        public string Tokui_Cd { get; set; }

        public string Tokui_Name { get; set; }

        public string Tantosha_Cd { get; set; }

        public string Shiharai_Cd { get; set; }

        public string Yuko_Kigen_Cd { get; set; }
    }
}