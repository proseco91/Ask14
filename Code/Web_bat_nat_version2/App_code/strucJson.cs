using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Class1
/// </summary>
/// 



public class accccc {
    public object ID { get; set; }
    public object CATEGORYNAME { get; set; }
    public object TITLE { get; set; }
    public object IMAGE { get; set; }
    public object SUMMARY { get; set; }
    public object CREATED_DATE { get; set; }
    public object RowNumber { get; set; }
    public object RecordsTotal { get; set; }
}

public class strucJson
{
    public strucJson()
    {
        //
        // TODO: Add constructor logic here
        //
    }
}
public class ObjAvar
{
    public string avar { get; set; }
}

public class Obj1
{
    public string DateOfTest { get; set; }
    public string SecondChoice { get; set; }
}

public class Obj2
{
    public string LastName { get; set; }
}

public class Obj3
{
    public string Title { get; set; }
}

public class Obj4
{
    public string FirstName { get; set; }
}

public class Obj5
{
    public string Address { get; set; }
}

public class Obj6
{
    public string Telephone { get; set; }
}

public class Obj7
{
    public string Email { get; set; }
}

public class Obj8
{
    public string DateOfBirth { get; set; }
}

public class Obj9
{
    public int Gender { get; set; }
}

public class Obj10
{
    public string CardNumber { get; set; }
    public string TypeCare { get; set; }
    public string fileCard { get; set; }
}

public class Obj11
{
    public string CountryCode { get; set; }
    public string CountryName { get; set; }
}

public class Obj12
{
    public string LangCode { get; set; }
    public string LangName { get; set; }
}

public class Obj13
{
    public string SectorCode { get; set; }
    public string SectorName { get; set; }
    public string LevelCode { get; set; }
    public string LevelName { get; set; }
}

public class Obj14
{
    public string TalkingCode { get; set; }
    public string TalkingName { get; set; }
}

public class Obj15
{
    public string CountryApplying { get; set; }
}

public class Obj16
{
    public string WhichIELTS { get; set; }
}

public class Obj17
{
    public string HaveIELTS { get; set; }
}

public class Obj18
{
    public string CentreName { get; set; }
    public string CentreNumber { get; set; }
    public string CentreDate { get; set; }
}

public class Obj19
{
    public string StudyingEnglish { get; set; }
}

public class Obj20
{
    public string Completed { get; set; }
}

public class Obj21
{
    public string StudyingEnglish { get; set; }
}

public class Obj22
{
    public string YesOrNo { get; set; }
    public string Text { get; set; }
}

public class jsonStrucIELTS
{
    public ObjAvar objAvar { get; set; }
    public Obj1 obj1 { get; set; }
    public Obj2 obj2 { get; set; }
    public Obj3 obj3 { get; set; }
    public Obj4 obj4 { get; set; }
    public Obj5 obj5 { get; set; }
    public Obj6 obj6 { get; set; }
    public Obj7 obj7 { get; set; }
    public Obj8 obj8 { get; set; }
    public Obj9 obj9 { get; set; }
    public Obj10 obj10 { get; set; }
    public Obj11 obj11 { get; set; }
    public Obj12 obj12 { get; set; }
    public Obj13 obj13 { get; set; }
    public Obj14 obj14 { get; set; }
    public Obj15 obj15 { get; set; }
    public Obj16 obj16 { get; set; }
    public Obj17 obj17 { get; set; }
    public Obj18 obj18 { get; set; }
    public Obj19 obj19 { get; set; }
    public Obj20 obj20 { get; set; }
    public Obj21 obj21 { get; set; }
    public Obj22 obj22 { get; set; }
}
public class ArrTL
{
    public string ID { get; set; }
    public string Index { get; set; }
    public string txtTieuDe { get; set; }
    public bool @checked { get; set; }
    public bool checkedReturn { get; set; }
    public string cautraloidung { get; set; }
    public string giaidap { get; set; }
}

public class ArrQuest
{
    public string ID { get; set; }
    public string Index { get; set; }
    public string txtTieuDe { get; set; }
    public int tongDiem { get; set; }
    public string typeQuest { get; set; }

    public TypeImg typeImg { get; set; }
    public TypeDichAnhViet typeDichAnhViet { get; set; }
    public TypeChonLua typeChonLua { get; set; }
    public TypeNghe typeNghe { get; set; }


    public List<ArrTL> arrTL { get; set; }
}

public class TypeImg
{
    public string typeImgImg { get; set; }
    public string typeImgAnh { get; set; }
    public string typeImgViet { get; set; }
}

public class TypeDichAnhViet
{
    public string typeDichAnhVietAnh { get; set; }
    public string typeDichAnhVietViet { get; set; }
    public List<string[]> arrSplit = new List<string[]>();
    public List<string[]> arrDich = new List<string[]>();
    public string fullText;
    public string fullTextDich;
    public List<string> arrCauDung = new List<string>();
    public List<object[]> arrMaoTu = new List<object[]>();
}


public class TypeChonLua
{
    public string typeChonLuaFull { get; set; }
    public string typeChonLuaChonLua { get; set; }
    public string[] arrChonLua;
    public string txtShow;
}

public class TypeNghe
{
    public string typeNgheFull { get; set; }
}
public class TypeMulti
{
    public string typeMutiHoi { get; set; }
    public string typeMutiArr { get; set; }

    public List<string> arrRe { get; set; }
}

public class Pram
{
    public string ID { get; set; }
    public string Index { get; set; }
    public int PhanThi { get; set; }
    public string txtTieuDe { get; set; }
    public string totalQuest { get; set; }
    public string tag { get; set; }
    public string isCopy { get; set; }
    public bool isAutoCreate { get; set; }
    public string doKho { get; set; }
    public string audioFile { get; set; }
    public string textGoiY { get; set; }
    public string imageGoiY { get; set; }
    public int typePram { get; set; }
    public List<ArrQuest> arrQuest { get; set; }
    public int Index_Num { get; set; }
    public List<ArrQuestDuolingo> arrQuestDuolingo { get; set; }
}
public class ArrQuestDuolingo
{
    public string ID { get; set; }
    public List<arrQChi> arrQChi { get; set; }
    public string Index { get; set; }
}


public class ArrVocab
{
    public string ID { get; set; }
    public string words { get; set; }
    public string image1 { get; set; }

    //public string IDWord2 { get; set; }
    //public string word2{ get; set; }
    //public string image2 { get; set; }

    //public string IDWord3 { get; set; }
    //public string word3 { get; set; }
    //public string image3 { get; set; }
}


public class arrQChi
{
    public string IDAuto { get; set; }
    public string typeQuest { get; set; }
    public TypeImg typeImg { get; set; }
    public TypeDichAnhViet typeDichAnhViet { get; set; }
    public TypeChonLua typeChonLua { get; set; }
    public TypeNghe typeNghe { get; set; }
    public TypeMulti typeMulti { get; set; }
    public bool status = false;

    public bool statusVietAnh = false;
    public bool statusAnhViet = false;
    public bool statusNghe = false;
    public bool statusNoi = false;
    public bool statusMulti = false;
    public int showDich = -1;
    public int showNgheNoi = -1;
    public string txtErr = "";
    public bool statusDung = false;
}
public class strucAnse
{
    public string ID { get; set; }
    public int type { get; set; }
    public bool valueChecked { get; set; }
    public string valueText { get; set; }
    public string ID_DE { get; set; }
}

public class strucNewQuestErr
{
    public string html { get; set; }
}
public class strucObjSubmit
{
    public int typeQuest { get; set; }
    public string txtTraLoi { get; set; }
    public string IDAuto { get; set; }
    public int typeQuestType { get; set; }
}
public class Hypothesis
{
    public string utterance { get; set; }
    public double confidence { get; set; }
}

public class strucDichNoiOld
{
    public int status { get; set; }
    public string id { get; set; }
    public List<Hypothesis> hypotheses { get; set; }
}

public class alternative
{
    public string transcript { get; set; }
    public double confidence { get; set; }
}

public class result
{
    public List<alternative> alternative { get; set; }
    public bool final { get; set; }
}

public class strucDichNoi
{
    public List<result> result { get; set; }
    public int result_index { get; set; }
}


public class ItemPanelKeoTha
{
    public string title { get; set; }
    public string content { get; set; }
    public List<ItemPanelKeoThaItem> item { get; set; }
}
public class ItemPanelKeoThaItem
{
    public string ID { get; set; }
    public string title { get; set; }
    public string titletrue { get; set; }
    public string A { get; set; }
    public string B { get; set; }
}
public class ItemDienCau
{
    public string title { get; set; }
    public string content { get; set; }
    public List<ItemDienCauItem> arrayItem { get; set; }
}
public class ItemDienCauItem
{
    public string ID { get; set; }
    public List<string> dapan { get; set; }
}
public class ItemMatching
{
    public string title { get; set; }
    public string content { get; set; }
    public List<ItemMatchingItem> item { get; set; }
}
public class ItemMatchingItem
{
    public string ID { get; set; }
    public string title { get; set; }
    public string dapan { get; set; }
    public ItemMatchingItem(string ID, string title, string dapan)
    {
        this.ID = ID;
        this.title = title;
        this.dapan = dapan;
    }
}
public class ItemPhanLoai
{
    public string title { get; set; }
    public string title1 { get; set; }
    public string content1 { get; set; }
    public string title2 { get; set; }
    public string content2 { get; set; }
    public string[] A { get; set; }
    public string[] B { get; set; }
}

public class ItemLuaChon
{
    public string title { get; set; }
    public string content { get; set; }
    public List<ItemChonLuaDapAn> arrayDapAn { get; set; }
}
public class ItemChonLuaDapAn
{
    public string ID { get; set; }
    public int numberChon { get; set; }
    public string title { get; set; }
    public List<ItemChonLuaDapAnItem> item { get; set; }
}
public class ItemChonLuaDapAnItem
{
    public string title { get; set; }
    public bool isChecked { get; set; }
    public string giaithich = "";
    public ItemChonLuaDapAnItem(string title, bool isChecked)
    {
        this.title = title;
        this.isChecked = isChecked;
    }
    public ItemChonLuaDapAnItem(string title, bool isChecked, string giaithich)
    {
        this.title = title;
        this.isChecked = isChecked;
        this.giaithich = giaithich;
    }
}
public class Offset
{
    public double top { get; set; }
    public double left { get; set; }
}
public class ArrayPixel
{
    public string ID { get; set; }
    public string text { get; set; }
    public Offset offset { get; set; }
}
public class ItemImage
{
    public string title { get; set; }
    public string urlimage { get; set; }
    public int width { get; set; }
    public int height { get; set; }
    public List<ArrayPixel> arrayPixel { get; set; }
}

public class ArrayQuestion
{
    public int type { get; set; }
    public ItemPanelKeoTha itemPanelKeoTha { get; set; }
    public ItemDienCau itemDienCau { get; set; }
    public ItemMatching itemMatching { get; set; }
    public ItemPhanLoai itemPhanLoai { get; set; }
    public ItemLuaChon itemLuaChon { get; set; }
    public ItemImage itemImage { get; set; }
    public string html { get; set; }
    public string htmltrue { get; set; }
    public string ID { get; set; }
    public string itembaihoclienquan { get; set; }
}

public class StrucQuestionNew
{
    public List<ArrayQuestion> arrayQuestion { get; set; }
    public string title { get; set; }
}



public class Arrayitem
{
    public string id { get; set; }
    public string a { get; set; }
    public string b { get; set; }
    public string dapan { get; set; }
}

public class Strucsaveactionnew
{
    public string id { get; set; }
    public int type { get; set; }
    public List<Arrayitem> arrayitem { get; set; }
    public List<object> a { get; set; }
    public List<object> b { get; set; }
    public string html { get; set; }
    public bool isTrue { get; set; }
}