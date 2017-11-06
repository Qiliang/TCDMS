using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TCSOFT.DMS.MasterData.DTO;
using TCSOFT.DMS.WebMain.Common;
using TCSOFT.DMS.WebMain.Models.Provider;

namespace TCSOFT.DMS.WebMain.Areas.MasterData.Models.Provider
{
    using TCSOFT.DMS.Common;
    using TCSOFT.DMS.MasterData.DTO.Common;
    using WebMain.Models.Model;
    /// <summary>
    /// 公共数据提供
    /// </summary>
    public class CommonProvider : BaseProvider
    {
        /// <summary>
        /// 获取权限
        /// </summary>
        /// <param name="strIdlst">用户或者角色ID</param>
        /// <param name="type">1：用户类型 2：角色类型</param>
        /// <param name="showroletype">0：系统管理员 1：贝克曼 2：经销商</param>
        /// <param name="roletype">0：系统管理员 1：贝克曼 2：经销商</param>
        /// <returns></returns>
        public static List<AuthorityTreeModel> GetAuthority(string strIdlst,int type,int showroletype,int? roletype=null)
        {
            List<AuthorityTreeModel> tempresultlst = new List<AuthorityTreeModel>();
            List<CurrentAuthorityDTO> pp = null;
            if ((!String.IsNullOrEmpty(strIdlst)) || type != 0 || roletype != null)
            {
                pp = GetAPI<List<CurrentAuthorityDTO>>(WebConfiger.MasterDataServicesUrl + "Common?strIdlst=" + strIdlst + "&type=" + type + "&roletype=" + roletype);
            }

            List<StructureDTO> lstResult = null;
            switch (showroletype)
            {
                case 0:
                    lstResult = Common.GlobalStaticData.StructureInfo;
                    break;
                case 1:
                    lstResult = Common.GlobalStaticData.StructureInfo.Where(p => p.StructureID.StartsWith("0") || p.StructureID.StartsWith("9")).ToList();
                    break;
                case 2:
                    lstResult = Common.GlobalStaticData.StructureInfo.Where(p => p.StructureID.StartsWith("1") || p.StructureID.StartsWith("9")).ToList();
                    break;
            }

            foreach (var p in lstResult)
            {
                AuthorityTreeModel atm = new AuthorityTreeModel();
                tempresultlst.Add(atm);
                atm.StructureID = p.StructureID;
                atm.ParentStructureID = p.ParentStructureID;
                atm.IndexCode = p.IndexCode;
                atm.IsVisible = p.IsVisible;
                atm.StructureName = p.StructureName;
                atm.DesImage = p.DesImage;
                atm.Description = p.Description;
                atm.BelongButton = p.BelongButton;
                atm.ButtonAuthorityList = new List<AuthorityTreeButton>();
                foreach (var b in Common.GlobalStaticData.ButtonInfo)
                {
                    if ((b.ButtonID & p.BelongButton) == b.ButtonID)
                    {
                        AuthorityTreeButton atb = new AuthorityTreeButton();
                        atb.ButtonID = b.ButtonID;
                        atb.ButtonName = p.StructureID; // 方便前台控制以StructureID为组
                        atb.ButtonValue = b.ButtonValue;

                        var mm = pp != null ? pp.Where(g => g.StructureID == p.StructureID).FirstOrDefault() : null;
                        if (mm != null && ((mm.BelongButton & b.ButtonID) == b.ButtonID)) // 判断是否拥有权限
                        {
                            atb.IsChecked = true;
                        }
                        else
                        {
                            atb.IsChecked = false;
                        }

                        atm.ButtonAuthorityList.Add(atb);
                    }
                }
            }
            List<AuthorityTreeModel> resultlist = CreateTree(tempresultlst);
            resultlist = resultlist.OrderBy(g => g.StructureID).ThenBy(t=>t.IndexCode).ToList();

            // 返回树
            return resultlist;
        }

        /// <summary>
        /// 构建树
        /// </summary>
        /// <param name="tempresultlst">临时结果</param>
        /// <returns>构建结果</returns>
        private static List<AuthorityTreeModel> CreateTree(List<AuthorityTreeModel> tempresultlst)
        {
            List<AuthorityTreeModel> resultlst = new List<AuthorityTreeModel>();
            var pp = tempresultlst.Where(p => p.ParentStructureID == null).ToList();

            foreach (var p in pp)
            {
                AuthorityTreeModel st = Recursion(p, tempresultlst);
                resultlst.Add(st);
            }

            return resultlst;
        }

        private static AuthorityTreeModel Recursion(AuthorityTreeModel ssdto, List<AuthorityTreeModel> ssdtolist)
        {
            AuthorityTreeModel st = new AuthorityTreeModel();
            st = ssdto;
            st.children = new List<AuthorityTreeModel>();
            var pp = ssdtolist.Where(p => p.ParentStructureID == ssdto.StructureID).ToList();
            foreach (var p in pp)
            {
                st.children.Add(Recursion(p, ssdtolist));
            }

            return st;
        }
        /// <summary>
        /// 获取角色权限
        /// </summary>
        /// <param name="intIdlst">角色ID</param>
        /// <param name="type">2：角色类型</param>
        /// <returns></returns>
        public static List<CurrentAuthorityDTO> GetAuthority(string strIdlst, int type, int? roletype = null)
        {
            var pp = GetAPI<List<CurrentAuthorityDTO>>(WebConfiger.MasterDataServicesUrl + "Common?strIdlst=" + strIdlst + "&type=" + type + "&roletype=" + roletype);

            return pp;
        }

    }
}