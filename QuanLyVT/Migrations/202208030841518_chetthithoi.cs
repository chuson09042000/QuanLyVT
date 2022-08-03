namespace QuanLyVT.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class chetthithoi : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.BAO_TRI",
                c => new
                    {
                        ID_BAO_TRI = c.Int(nullable: false, identity: true),
                        Ma_Bao_Tri = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        Ngay_Bao_Tri = c.DateTime(nullable: false),
                        LK_ThayThe = c.String(nullable: false, maxLength: 500),
                        ID_THIET_BI = c.Int(nullable: false),
                        ID_HOP_DONG = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_BAO_TRI)
                .ForeignKey("dbo.HOP_DONG", t => t.ID_HOP_DONG)
                .ForeignKey("dbo.THIET_BI", t => t.ID_THIET_BI)
                .Index(t => t.ID_THIET_BI)
                .Index(t => t.ID_HOP_DONG);
            
            CreateTable(
                "dbo.HOP_DONG",
                c => new
                    {
                        ID_HOP_DONG = c.Int(nullable: false, identity: true),
                        Ma_HD = c.String(nullable: false, maxLength: 50, fixedLength: true),
                        TEN_HD = c.String(nullable: false, maxLength: 200),
                        Ngay_Hoan_Thanh = c.DateTime(nullable: false),
                        Han_BH = c.String(nullable: false, maxLength: 20),
                        Ghi_Chu = c.String(maxLength: 100, fixedLength: true),
                        FileName = c.String(maxLength: 500),
                        ID_THIET_BI = c.Int(nullable: false),
                        ID_BENH_VIEN = c.Int(nullable: false),
                        ID_NGUOI_PHU_TRACH = c.Int(nullable: false),
                        ID_NHAN_VIEN_KY_THUAT = c.Int(nullable: false),
                        So_Luong = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_HOP_DONG)
                .ForeignKey("dbo.BENH_VIEN", t => t.ID_BENH_VIEN)
                .ForeignKey("dbo.THIET_BI", t => t.ID_THIET_BI)
                .ForeignKey("dbo.NGUOI_PHU_TRACH", t => t.ID_NGUOI_PHU_TRACH)
                .ForeignKey("dbo.NHAN_VIEN_KY_THUAT", t => t.ID_NHAN_VIEN_KY_THUAT)
                .Index(t => t.ID_THIET_BI)
                .Index(t => t.ID_BENH_VIEN)
                .Index(t => t.ID_NGUOI_PHU_TRACH)
                .Index(t => t.ID_NHAN_VIEN_KY_THUAT);
            
            CreateTable(
                "dbo.BENH_VIEN",
                c => new
                    {
                        ID_BENH_VIEN = c.Int(nullable: false, identity: true),
                        Ma_BV = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        Ten_BV = c.String(nullable: false, maxLength: 100),
                        Dia_Chi = c.String(nullable: false, maxLength: 350),
                        SDT = c.String(maxLength: 50),
                        Fax = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.ID_BENH_VIEN);
            
            CreateTable(
                "dbo.THIET_BI",
                c => new
                    {
                        ID_THIET_BI = c.Int(nullable: false, identity: true),
                        Ma_TB = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        Ten_TB = c.String(nullable: false, maxLength: 200),
                        XX_TC = c.String(nullable: false, maxLength: 50),
                        Nam_SX = c.String(nullable: false, maxLength: 4),
                        ID_BENH_VIEN = c.Int(nullable: false),
                        ID_GOI_THAU = c.Int(nullable: false),
                        ID_LINH_KIEN = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_THIET_BI)
                .ForeignKey("dbo.GOI_THAU", t => t.ID_GOI_THAU)
                .ForeignKey("dbo.LINH_KIEN", t => t.ID_LINH_KIEN)
                .ForeignKey("dbo.BENH_VIEN", t => t.ID_BENH_VIEN)
                .Index(t => t.ID_BENH_VIEN)
                .Index(t => t.ID_GOI_THAU)
                .Index(t => t.ID_LINH_KIEN);
            
            CreateTable(
                "dbo.GOI_THAU",
                c => new
                    {
                        ID_GOI_THAU = c.Int(nullable: false, identity: true),
                        Ma_Goi_Thau = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        Ten_Goi_Thau = c.String(nullable: false, maxLength: 50),
                        Du_An = c.String(nullable: false, maxLength: 300),
                    })
                .PrimaryKey(t => t.ID_GOI_THAU);
            
            CreateTable(
                "dbo.LINH_KIEN",
                c => new
                    {
                        ID_LINH_KIEN = c.Int(nullable: false, identity: true),
                        Ma_So_LK = c.String(nullable: false, maxLength: 15, fixedLength: true),
                        Ten_LK = c.String(nullable: false, maxLength: 200),
                        XX_TC = c.String(nullable: false, maxLength: 50),
                        Nam_SX = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        ID_DVT = c.Int(nullable: false),
                        ID_TINH_TRANG = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_LINH_KIEN)
                .ForeignKey("dbo.DVT", t => t.ID_DVT)
                .ForeignKey("dbo.TINH_TRANG", t => t.ID_TINH_TRANG)
                .Index(t => t.ID_DVT)
                .Index(t => t.ID_TINH_TRANG);
            
            CreateTable(
                "dbo.DVT",
                c => new
                    {
                        ID_DVT = c.Int(nullable: false, identity: true),
                        Ma_DVT = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        Ten_DVT = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ID_DVT);
            
            CreateTable(
                "dbo.TINH_TRANG",
                c => new
                    {
                        ID_TINHTRANG = c.Int(nullable: false, identity: true),
                        Ma_TT_LK = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        Ten_TT_LK = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.ID_TINHTRANG);
            
            CreateTable(
                "dbo.SUA_CHUA",
                c => new
                    {
                        ID_SUA_CHUA = c.Int(nullable: false, identity: true),
                        Ma_Sua_Chua = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        Ngay_Sua_Chua = c.DateTime(nullable: false),
                        LK_ThayThe = c.String(nullable: false, maxLength: 500),
                        ID_HOP_DONG = c.Int(nullable: false),
                        ID_THIET_BI = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_SUA_CHUA)
                .ForeignKey("dbo.THIET_BI", t => t.ID_THIET_BI)
                .ForeignKey("dbo.HOP_DONG", t => t.ID_HOP_DONG)
                .Index(t => t.ID_HOP_DONG)
                .Index(t => t.ID_THIET_BI);
            
            CreateTable(
                "dbo.NGUOI_PHU_TRACH",
                c => new
                    {
                        ID_NGUOI_PHU_TRACH = c.Int(nullable: false, identity: true),
                        Ma_Nguoi_Phu_Trach = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        Ten_Nguoi_Phu_Trach = c.String(nullable: false, maxLength: 50),
                        Ma_BV = c.String(maxLength: 10, fixedLength: true),
                        Chuc_Vu = c.String(nullable: false, maxLength: 50),
                        So_Dien_Thoai = c.String(maxLength: 12),
                        ID_BENH_VIEN = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_NGUOI_PHU_TRACH)
                .ForeignKey("dbo.BENH_VIEN", t => t.ID_BENH_VIEN, cascadeDelete: true)
                .Index(t => t.ID_BENH_VIEN);
            
            CreateTable(
                "dbo.NHAN_VIEN_KY_THUAT",
                c => new
                    {
                        ID_NHAN_VIEN_KY_THUAT = c.Int(nullable: false, identity: true),
                        Ma_NV_KT = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        Ten_NV_KT = c.String(nullable: false, maxLength: 50),
                        Chuc_Vu = c.String(nullable: false, maxLength: 50),
                        So_Dien_Thoai = c.String(maxLength: 12),
                    })
                .PrimaryKey(t => t.ID_NHAN_VIEN_KY_THUAT);
            
            CreateTable(
                "dbo.NGUOI_DUNG",
                c => new
                    {
                        ID_NGUOI_DUNG = c.Int(nullable: false, identity: true),
                        Ma_Nguoi_Dung = c.String(nullable: false, maxLength: 10, fixedLength: true),
                        Ten_Nguoi_Dung = c.String(nullable: false, maxLength: 50),
                        Mat_Khau = c.String(nullable: false, maxLength: 50),
                        ID_PHAN_QUYEN = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID_NGUOI_DUNG)
                .ForeignKey("dbo.PHAN_QUYEN", t => t.ID_PHAN_QUYEN)
                .Index(t => t.ID_PHAN_QUYEN);
            
            CreateTable(
                "dbo.PHAN_QUYEN",
                c => new
                    {
                        ID_PHAN_QUYEN = c.Int(nullable: false, identity: true),
                        Ma_Phan_Quyen = c.String(nullable: false, maxLength: 5),
                        Ten_Quyen = c.String(nullable: false, maxLength: 50),
                    })
                .PrimaryKey(t => t.ID_PHAN_QUYEN);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.NGUOI_DUNG", "ID_PHAN_QUYEN", "dbo.PHAN_QUYEN");
            DropForeignKey("dbo.SUA_CHUA", "ID_HOP_DONG", "dbo.HOP_DONG");
            DropForeignKey("dbo.HOP_DONG", "ID_NHAN_VIEN_KY_THUAT", "dbo.NHAN_VIEN_KY_THUAT");
            DropForeignKey("dbo.HOP_DONG", "ID_NGUOI_PHU_TRACH", "dbo.NGUOI_PHU_TRACH");
            DropForeignKey("dbo.NGUOI_PHU_TRACH", "ID_BENH_VIEN", "dbo.BENH_VIEN");
            DropForeignKey("dbo.THIET_BI", "ID_BENH_VIEN", "dbo.BENH_VIEN");
            DropForeignKey("dbo.SUA_CHUA", "ID_THIET_BI", "dbo.THIET_BI");
            DropForeignKey("dbo.LINH_KIEN", "ID_TINH_TRANG", "dbo.TINH_TRANG");
            DropForeignKey("dbo.THIET_BI", "ID_LINH_KIEN", "dbo.LINH_KIEN");
            DropForeignKey("dbo.LINH_KIEN", "ID_DVT", "dbo.DVT");
            DropForeignKey("dbo.HOP_DONG", "ID_THIET_BI", "dbo.THIET_BI");
            DropForeignKey("dbo.THIET_BI", "ID_GOI_THAU", "dbo.GOI_THAU");
            DropForeignKey("dbo.BAO_TRI", "ID_THIET_BI", "dbo.THIET_BI");
            DropForeignKey("dbo.HOP_DONG", "ID_BENH_VIEN", "dbo.BENH_VIEN");
            DropForeignKey("dbo.BAO_TRI", "ID_HOP_DONG", "dbo.HOP_DONG");
            DropIndex("dbo.NGUOI_DUNG", new[] { "ID_PHAN_QUYEN" });
            DropIndex("dbo.NGUOI_PHU_TRACH", new[] { "ID_BENH_VIEN" });
            DropIndex("dbo.SUA_CHUA", new[] { "ID_THIET_BI" });
            DropIndex("dbo.SUA_CHUA", new[] { "ID_HOP_DONG" });
            DropIndex("dbo.LINH_KIEN", new[] { "ID_TINH_TRANG" });
            DropIndex("dbo.LINH_KIEN", new[] { "ID_DVT" });
            DropIndex("dbo.THIET_BI", new[] { "ID_LINH_KIEN" });
            DropIndex("dbo.THIET_BI", new[] { "ID_GOI_THAU" });
            DropIndex("dbo.THIET_BI", new[] { "ID_BENH_VIEN" });
            DropIndex("dbo.HOP_DONG", new[] { "ID_NHAN_VIEN_KY_THUAT" });
            DropIndex("dbo.HOP_DONG", new[] { "ID_NGUOI_PHU_TRACH" });
            DropIndex("dbo.HOP_DONG", new[] { "ID_BENH_VIEN" });
            DropIndex("dbo.HOP_DONG", new[] { "ID_THIET_BI" });
            DropIndex("dbo.BAO_TRI", new[] { "ID_HOP_DONG" });
            DropIndex("dbo.BAO_TRI", new[] { "ID_THIET_BI" });
            DropTable("dbo.PHAN_QUYEN");
            DropTable("dbo.NGUOI_DUNG");
            DropTable("dbo.NHAN_VIEN_KY_THUAT");
            DropTable("dbo.NGUOI_PHU_TRACH");
            DropTable("dbo.SUA_CHUA");
            DropTable("dbo.TINH_TRANG");
            DropTable("dbo.DVT");
            DropTable("dbo.LINH_KIEN");
            DropTable("dbo.GOI_THAU");
            DropTable("dbo.THIET_BI");
            DropTable("dbo.BENH_VIEN");
            DropTable("dbo.HOP_DONG");
            DropTable("dbo.BAO_TRI");
        }
    }
}
