using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HesabuPOS.MasterData.Models.Data.BaseData
{
    public class UnifiedArticle
    {
        public ArticleData ArticleData { get; set; }
        public List<ArticleVariantData> Variants { get; set; }
    }
}
