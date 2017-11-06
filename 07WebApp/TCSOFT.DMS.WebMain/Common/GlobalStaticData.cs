using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TCSOFT.DMS.WebMain.Common
{
    using MasterData.DTO;
    using Models.Provider;
    using MasterData.DTO.Common;
    using Areas.MasterData.Models.Provider;
    public class GlobalStaticData
    {
        private static List<StructureDTO> _StructureInfo = null;
        /// <summary>
        /// 结构信息
        /// </summary>
        public static List<StructureDTO> StructureInfo
        {
            get
            {
                if (_StructureInfo == null)
                {
                    _StructureInfo = HomeProvider.GetStructureInfo();
                }

                return _StructureInfo;
            }
        }

        private static List<ButtonDTO> _ButtonInfo = null;
        /// <summary>
        /// 按钮信息
        /// </summary>
        public static List<ButtonDTO> ButtonInfo
        {
            get
            {
                if (_ButtonInfo == null)
                {
                    _ButtonInfo = HomeProvider.GetButtonInfo();
                }

                return _ButtonInfo;
            }
        }
        private static List<RegionResultDTO> _RegionList = null;
        /// <summary>
        /// 行政区域信息
        /// </summary>
        public static List<RegionResultDTO> RegionList
        {
            get
            {
                if (_RegionList == null)
                {
                    _RegionList = AreaRegionProvider.GetRegionList();
                }

                return _RegionList;
            }
            set
            {
                _RegionList = value;
            }
        }
    }
}