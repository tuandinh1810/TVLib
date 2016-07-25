using System;
using System.Data;
using System.Windows.Forms;

namespace TruongViet.Lib.Win
{
    /// <summary>
    /// Summary description for cTreeView.
    /// </summary>
    public class TVTreeView : LibBase
    {
        private static DataView mdtvDuLieu;
        private static string mTenTruongCha;
        private static string mTenTruongKhoa;
        private static string mTenTruongText;

        // Ham tao
        public TVTreeView() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dtvDuLieu"></param>
        /// <param name="TenTruongKhoa"></param>
        /// <param name="TenTruongText"></param>
        /// <param name="TenTruongCha"></param>
        public TVTreeView(DataView dtvDuLieu, string TenTruongKhoa, string TenTruongText, string TenTruongCha)
        {
            mdtvDuLieu = dtvDuLieu;
            mTenTruongKhoa = TenTruongKhoa;
            mTenTruongText = TenTruongText;
            mTenTruongCha = TenTruongCha;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="nodeGoc"></param>
        /// <param name="ID_Cha"></param>
        public static void TaoNodes(TreeNode nodeGoc, int ID_Cha)
        {
            // Loc ra cac du lieu con
            mdtvDuLieu.RowFilter = mTenTruongCha + " = " + ID_Cha.ToString();
            int Count = mdtvDuLieu.Count;
            for (int i = 0; i < Count; i++)
            {
                // Tao nhanh thu i
                TreeNode treeNode = TaoNode(int.Parse(mdtvDuLieu[i][mTenTruongKhoa].ToString()), mdtvDuLieu[i][mTenTruongText].ToString());
                nodeGoc.Nodes.Add(treeNode);
                // Tao cac nhanh con cua nhanh thu i                
                TaoNodes(nodeGoc.Nodes[i], int.Parse(mdtvDuLieu[i][mTenTruongKhoa].ToString()));
                // Khoi phuc lai trang thai cua du lieu sau khi cac nhanh con de quy xong
                // Vi DataView duoc truyen theo kieu ref trong qua trinh de quy
                mdtvDuLieu.RowFilter = mTenTruongCha + " = " + ID_Cha.ToString();
            }
        }

        /// <summary>
        /// Hàm tạo node cho cây với 2 thuộc tính Khóa và Text
        /// </summary>
        /// <param name="mKhoa"></param>
        /// <param name="mText"></param>
        /// <returns></returns>
        public static TreeNode TaoNode(int mKhoa, string mText)
        {
            TreeNode treeNode = new TreeNode();
            treeNode.Tag = mKhoa;
            treeNode.Text = mText;
            return treeNode;
        }

       /// <summary>
       /// Hàm duyệt cây tại một Node nào đó và lấy ra danh sách ID của các Node trong nhánh đó của TreeView
       /// </summary>
       /// <param name="treeNode">Node nào đó trong cây</param>
       /// <param name="sTruongKhoa">Tên trường khóa cần duyệt</param>
       /// <returns>Xâu kết quả dạng : ID_DonVi IN (1,2,3,4,...)</returns>
        public static string DuyetTreeView(TreeNode treeNode, string sTruongKhoa)
        {
            string sID= "";
            LayNodeDonVi(treeNode, ref sID);
            if (sID.Length > 0)
            {
                if (sID.Substring(0, 1) == ",") sID = " " + sTruongKhoa + " IN (" + sID.Substring(1) + ") ";
            }
            return sID;
        }

        /// <summary>
        /// Lấy Node đơn vị
        /// </summary>
        /// <param name="treeNode"></param>
        /// <param name="sID"></param>
        private static void LayNodeDonVi(TreeNode treeNode, ref string sID)
        {
            sID= sID+ "," + treeNode.Tag.ToString();
            if (treeNode.Nodes.Count > 0)
            {
                for (int i = 0; i < treeNode.Nodes.Count; i++)
                {
                    LayNodeDonVi(treeNode.Nodes[i],ref sID);
                }
            }
        }

        
        /// <summary>
        /// Lấy gốc cây
        /// </summary>
        /// <param name="treeNode"></param>
        /// <returns></returns> 
        public static TreeNode LayGocCay(TreeView treeView)
        {
            //try
            //{
            //    while (treeNode.Parent != null)
            //    {
            //        treeNode = treeNode.Parent;
            //    }
            //}
            //catch { }
            return treeView.Nodes[0];
        }
    }
}