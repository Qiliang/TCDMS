using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TCSOFT.DMS.MasterData.DTO.Distributor.Distributor
{
    public class DistributorChangeNameDTO
    {
        /// <summary>
        /// 老经销商ID
        /// </summary>
        public Guid? OleDepID { get; set; }
        /// <summary>
        /// 新经销商ID
        /// </summary>
        public Guid? NewDepID { get; set; }
        /// <summary>
        /// 预测数据
        /// </summary>
        public bool Prediction { get; set; }
        /// <summary>
        /// 即时消息
        /// </summary>
        public bool Messaging { get; set; }
        /// <summary>
        /// 销售数据
        /// </summary>
        public bool Sales { get; set; }
        /// <summary>
        /// 信息提示栏
        /// </summary>
        public bool Information { get; set; }
        /// <summary>
        /// 库存数据s
        /// </summary>
        public bool Inventory { get; set; }
        /// <summary>
        /// 中文简介系统公告
        /// </summary>
        public bool ProfileBulletin { get; set; }
        /// <summary>
        /// 普通合同
        /// </summary>
        public bool GeneralContract { get; set; }
        /// <summary>
        /// 租赁合同
        /// </summary>
        public bool LeaseContract { get; set; }
        /// <summary>
        /// OKC价
        /// </summary>
        public bool OKCPrice { get; set; }
        /// <summary>
        /// 价格启用/禁用状态
        /// </summary>
        public bool PriceStatus { get; set; }
        /// <summary>
        /// 最低订货量
        /// </summary>
        public bool MinimumOrderQuantity { get; set; }
        /// <summary>
        /// 最小订单金额
        /// </summary>
        public bool MinimumOrderAmount { get; set; }
        /// <summary>
        /// 反应杯余额
        /// </summary>
        public bool ReactionCupBalance { get; set; }
        /// <summary>
        /// FOC余额
        /// </summary>
        public bool FOCBalance { get; set; }
        /// <summary>
        /// 库存最后一个月的数据复制到新经销商的初期库存
        /// </summary>
        public bool InventoryInitialInventory { get; set; }
    }
}
