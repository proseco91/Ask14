using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Newtonsoft.Json;

public partial class View_run_quiz : System.Web.UI.Page
{
    LinqDataContext sql = new LinqDataContext();
    tblQuiz _quiz;
    public int totalEx = 0, totalQues = 0;
    public double totalSec = 0;
    public string keyguid = Guid.NewGuid().ToString().Trim();
    protected void Page_Load(object sender, EventArgs e)
    {
        
        _quiz = (from p in sql.tblQuizs where p.ID == Convert.ToInt32(Request.QueryString["ID"]) && p.Status==1 select p).FirstOrDefault();
        if (_quiz == null)
            Response.Redirect("~/thu-vien/ct61.htm",true);
        DateTime _dateS = DateTime.Now;
        totalSec = (_dateS.AddMinutes(Convert.ToInt32(_quiz.Min)) - _dateS).TotalSeconds;
        this.Title = "Ask14.vn " + _quiz.Title;
    }
    public List<StrucQuestionNew> getQuestion()
    {

        return JsonConvert.DeserializeObject<List<StrucQuestionNew>>(_quiz.Question);

    }
    public int getTotalQuestion(List<StrucQuestionNew> _array)
    {
        int _cou = 0;
        foreach (StrucQuestionNew item in _array)
        {
            _cou += item.arrayQuestion.Count;
        }
        return _cou;
    }
    public string getHTMLContentQuestion(List<ArrayQuestion> arrayQuestion)
    {
        
        string html = "";

        Session["Aray-ID-Struc-New"] = new List<string>();
        int numberA = 0;
        foreach (ArrayQuestion item in arrayQuestion)
        {
            try
            {
                numberA++;
                html += "<span attr-number-question><span attr-number-question-content>Question " + numberA + "<span attr-number-question-eff></span></span> <span attr-number-question-eff2></span></span>";
                html += "<div class=\"contentListEx-itemparent-data-item\">";
                if (item.type == 0)
                {
                    html += createKeoThaCau(item);
                }
                else if (item.type == 1)
                {
                    html += createHoanThanhDoanVan(item);
                }
                else if (item.type == 2)
                {
                    html += createMatching(item);
                }
                else if (item.type == 3)
                {
                    html += createPhanLoai(item);
                }
                else if (item.type == 4)
                {
                    html += createChonLua(item);
                }
                else if (item.type == 5)
                {
                    html += createImage(item);
                }
                html += "<div class=\"panelShowErrSucNew\"></div>";
                html += "<div class=\"btnshowErrInfoQuestion btnshowErrInfoQuestion-ShowDa\" dis-mousedown=\"true\"><span>Bạn làm</span><span>Đáp án</span></div>";
                html += "   <div style=\"clear:both;\"></div>";
                html += "</div>";
            }
            catch (Exception)
            {
                throw new Exception("Cấu trúc sai. Xem lại câu :" + item.itemDienCau.title);
            }
        }
        totalEx++;
        return html;
    }
    public string createHoanThanhDoanVan(ArrayQuestion question)
    {
        ItemDienCau item = question.itemDienCau;
        string ID = createID();
        question.ID = ID;
        item.arrayItem = new List<ItemDienCauItem>();
        Regex _reRe = new Regex("\n|\t\n");
        Regex _reMatch = new Regex("{.+?}");
        item.content = _reRe.Replace(item.content, "<br/>");
        question.htmltrue = item.content;
        foreach (Match itemM in _reMatch.Matches(item.content))
        {
            ItemDienCauItem _objDA = new ItemDienCauItem();
            _objDA.ID = createID();
            string htmlRe = "<span valid=\"" + _objDA.ID + "\" class=\"panelDienCau-Content-AddText\"><span class=\"panelDienCau-Content-AddText-Num\">(" + (item.arrayItem.Count + 1) + ")</span><span class=\"panelDienCau-Content-AddText-Data\"></span><input type=\"text\" /></span>";
            item.content = Lib.ReplaceOne(item.content, itemM.Groups[0].Value, htmlRe);
            _objDA.dapan = new List<string>();
            string dap_an = itemM.Groups[0].Value.Replace("{", "").Replace("}", "");
            _objDA.dapan.AddRange(dap_an.Split('/').Where(d => !string.IsNullOrEmpty(d)).ToArray());
            item.arrayItem.Add(_objDA);
            string[] aNew = _objDA.dapan.ToArray();
            string htmlReNew = "<span valid=\"" + _objDA.ID + "\" class=\"panelDienCau-Content-AddText\"><span class=\"panelDienCau-Content-AddText-Num\">(" + (item.arrayItem.Count) + ")</span><span class=\"panelDienCau-Content-AddText-Data\">" + string.Join(" or ", aNew) + "</span><input type=\"text\" value=\"" + string.Join(" or ", aNew) + "\"/></span>";
            question.htmltrue = Lib.ReplaceOne(question.htmltrue, itemM.Groups[0].Value, htmlReNew);
        }

        string htmlTrue = question.htmltrue;
        question.htmltrue = "<div class=\"panelDienCau\" valid=\"" + ID + "\" valtype=\"" + question.type + "\">";
        question.htmltrue += getTitleQuestion(item.title);
        question.htmltrue += "<div class=\"panelDienCau-Content\">";
        question.htmltrue += htmlTrue;
        question.htmltrue += "</div>";
        question.htmltrue += "</div>";

        string html = "";
        html += "<div class=\"panelDienCau\" valid=\"" + ID + "\" valtype=\"" + question.type + "\">";
        html += getTitleQuestion(item.title);
        html += "<div class=\"panelDienCau-Content\">";
        html += item.content;
        html += "</div>";
        html += "</div>";
        question.html = html;
        return question.html;
    }
    public string getTitleQuestion(string title)
    {
        if (!String.IsNullOrEmpty(Lib.removeHTMLAll(HttpUtility.HtmlDecode(title))))
            return "<div class=\"title-question-struc-new\">" + title + "</div>";
        else
            return "";
    }
    public string createKeoThaCau(ArrayQuestion question)
    {
        ItemPanelKeoTha item = question.itemPanelKeoTha;
        string ID = createID();
        question.ID = ID;
        item.item = new List<ItemPanelKeoThaItem>();
        Regex _reSplit = new Regex("\n|\t\n");
        Regex _reMatch = new Regex("{.+?}");
        foreach (string itemRow in _reSplit.Split(item.content).Where(d => !string.IsNullOrEmpty(d)))
        {
            ItemPanelKeoThaItem _objItem = new ItemPanelKeoThaItem();
            _objItem.title = itemRow;
            _objItem.titletrue = itemRow;
            _objItem.ID = createID();
            MatchCollection itemDapAn = _reMatch.Matches(itemRow);
            if (itemDapAn.Count > 0)
            {
                _objItem.A = itemDapAn[0].Groups[0].Value.Replace("{", "").Replace("}", "");
                _objItem.title = Lib.ReplaceOne(_objItem.title, itemDapAn[0].Groups[0].Value, "<span class=\"panelKeoTha-Cau-ArrayTraLoi-Item-AddTl\" mouse-hover=\"false\" valtext=\"\"><span class=\"panelKeoTha-Cau-ArrayTraLoi-Item-AddTl-Hover\"></span><span class=\"panelKeoTha-Cau-ArrayTraLoi-Item-AddTl-Data\"></span></span>");
                _objItem.titletrue = Lib.ReplaceOne(_objItem.titletrue, itemDapAn[0].Groups[0].Value, "<span class=\"panelKeoTha-Cau-ArrayTraLoi-Item-AddTl addtextvalue\" mouse-hover=\"false\" valtext=\"" + _objItem.A + "\"><span class=\"panelKeoTha-Cau-ArrayTraLoi-Item-AddTl-Hover\"></span><span class=\"panelKeoTha-Cau-ArrayTraLoi-Item-AddTl-Data\">" + _objItem.A + "</span></span>");
            }
            if (itemDapAn.Count > 1)
            {
                _objItem.B = itemDapAn[1].Groups[0].Value.Replace("{", "").Replace("}", "");
                _objItem.title = Lib.ReplaceOne(_objItem.title, itemDapAn[1].Groups[0].Value, "<span class=\"panelKeoTha-Cau-ArrayTraLoi-Item-AddTl\" mouse-hover=\"false\" valtext=\"\"><span class=\"panelKeoTha-Cau-ArrayTraLoi-Item-AddTl-Hover\"></span><span class=\"panelKeoTha-Cau-ArrayTraLoi-Item-AddTl-Data\"></span></span>");
                _objItem.titletrue = Lib.ReplaceOne(_objItem.titletrue, itemDapAn[1].Groups[0].Value, "<span class=\"panelKeoTha-Cau-ArrayTraLoi-Item-AddTl addtextvalue\" mouse-hover=\"false\" valtext=\"" + _objItem.B + "\"><span class=\"panelKeoTha-Cau-ArrayTraLoi-Item-AddTl-Hover\"></span><span class=\"panelKeoTha-Cau-ArrayTraLoi-Item-AddTl-Data\">" + _objItem.B + "</span></span>");
            }
            if (itemDapAn.Count > 0)
            {
                item.item.Add(_objItem);
            }
        }
        item.item = item.item.OrderBy(d => Guid.NewGuid()).ToList();
        string[] arrA = (from p in item.item where !string.IsNullOrEmpty(p.A) select p.A).OrderBy(d => Guid.NewGuid()).ToArray();
        string[] arrB = (from p in item.item where !string.IsNullOrEmpty(p.B) select p.B).OrderBy(d => Guid.NewGuid()).ToArray();

        string html = "";
        html += "<div class=\"panelKeoTha-Cau\" mouse-move=\"false\" mouse-index=\"0\" valid=\"" + ID + "\" valtype=\"" + question.type + "\">";
        html += "<div class=\"title-question-struc-new\">" + item.title + "</div>";
        html += "<div class=\"panelKeoTha-Cau-ArrayKeo\">";
        if (arrA.Length > 0)
        {
            html += "<div class=\"panelKeoTha-Cau-ArrayKeo-Parent " + (arrB.Length <= 0 ? "panelKeoTha-Cau-ArrayKeo-Parent-NoShowAB" : "") + "\">";
            foreach (string itemA in arrA)
            {
                html += "<span class=\"panelKeoTha-Cau-ArrayKeo-Item\" mouse-move=\"false\" valtext=\"" + itemA + "\"><span>" + itemA + "</span></span>";
            }
            html += "</div>";
        }
        if (arrB.Length > 0)
        {
            html += "<div class=\"panelKeoTha-Cau-ArrayKeo-Parent\">";
            foreach (string itemB in arrB)
            {
                html += "<span class=\"panelKeoTha-Cau-ArrayKeo-Item\" mouse-move=\"false\" valtext=\"" + itemB + "\"><span>" + itemB + "</span></span>";
            }
            html += "</div>";
        }
        html += "</div>";
        html += "<div class=\"panelKeoTha-Cau-ArrayTraLoi " + (arrB.Length <= 0 ? "panelKeoTha-Cau-ArrayTraLoi-NoShowAB" : "") + "\">";
        int rowIndex = 0;
        question.htmltrue = html;
        foreach (ItemPanelKeoThaItem itemRow in item.item)
        {
            rowIndex++;
            html += "<div valid=\"" + itemRow.ID + "\" class=\"panelKeoTha-Cau-ArrayTraLoi-Item\"><span class=\"panelKeoTha-Cau-ArrayTraLoi-Item-Title\">" + rowIndex + ":</span>" + itemRow.title + "</div>";
            question.htmltrue += "<div valid=\"" + itemRow.ID + "\" class=\"panelKeoTha-Cau-ArrayTraLoi-Item\"><span class=\"panelKeoTha-Cau-ArrayTraLoi-Item-Title\">" + rowIndex + ":</span>" + itemRow.titletrue + "</div>";
        }
        question.htmltrue += "</div>";
        question.htmltrue += "</div>";
        question.htmltrue = question.htmltrue.Replace("panelKeoTha-Cau-ArrayKeo-Item", "panelKeoTha-Cau-ArrayKeo-Item dismovekeotha");

        html += "</div>";
        html += "</div>";
        question.html = html;
        return question.html;
    }
    public string createMatching(ArrayQuestion question)
    {
        ItemMatching item = question.itemMatching;
        string ID = createID();
        question.ID = ID;
        item.item = new List<ItemMatchingItem>();
        Regex _reSplit = new Regex("\n|\t\n");
        Regex _reMath = new Regex("{(.+?)}{(.+?)}");
        foreach (string itemRow in _reSplit.Split(item.content).Where(d => !string.IsNullOrEmpty(d)))
        {
            foreach (Match itemMath in _reMath.Matches(itemRow))
            {
                item.item.Add(new ItemMatchingItem(createID(), itemMath.Groups[1].Value, itemMath.Groups[2].Value));
            }
        }
        string html = "";
        html += "<div class=\"panelMatching\" mouse-move=\"false\" valid=\"" + ID + "\" valtype=\"" + question.type + "\">";
        html += getTitleQuestion(item.title);
        html += "<div class=\"panelMatching-Content\">";
        ItemMatchingItem[] arrayCauHoi = (from p in item.item select p).OrderBy(d => Guid.NewGuid()).ToArray();
        string[] arrayDapAn = (from p in item.item select p.dapan).OrderBy(d => Guid.NewGuid()).ToArray();
        question.htmltrue = html;
        for (int i = 0; i < item.item.Count; i++)
        {
            html += "<div class=\"panelMatching-Content-Item\" valtext=\"\" valid=\"" + arrayCauHoi[i].ID + "\">";
            html += "   <div class=\"panelMatching-Content-Item-Left\" mouse-move=\"false\">";
            html += "       <span class=\"panelMatching-Content-Title\">" + (i + 1) + ".</span>";
            html += "       <span class=\"panelMatching-Content-Item-Data\">" + arrayCauHoi[i].title + "</span>";
            html += "   </div>";
            html += "   <div class=\"panelMatching-Content-Item-Right\" mouse-hover=\"false\" valtext=\"" + arrayDapAn[i] + "\">";
            html += "       <span class=\"panelMatching-Content-Title\">" + ((Convert.ToChar(i + 65)).ToString()) + "</span>" + arrayDapAn[i];
            html += "   </div>";
            html += "   <div style=\"clear:both;\"></div>";
            html += "</div>";
            ItemMatchingItem _i = arrayCauHoi[i];
            question.htmltrue += "<div class=\"panelMatching-Content-Item\" valtext=\"" + _i.dapan + "\" valid=\"" + arrayCauHoi[i].ID + "\">";
            question.htmltrue += "   <div class=\"panelMatching-Content-Item-Left\" mouse-move=\"false\">";
            question.htmltrue += "       <span class=\"panelMatching-Content-Title\">" + (i + 1) + ".</span>";
            question.htmltrue += "       <span class=\"panelMatching-Content-Item-Data\">" + arrayCauHoi[i].title + "</span>";
            question.htmltrue += "   </div>";
            question.htmltrue += "   <div class=\"panelMatching-Content-Item-Right\" mouse-hover=\"false\" valtext=\"" + arrayDapAn[i] + "\">";
            question.htmltrue += "       <span class=\"panelMatching-Content-Title\">" + ((Convert.ToChar(i + 65)).ToString()) + "</span>" + arrayDapAn[i];
            question.htmltrue += "   </div>";
            question.htmltrue += "   <div style=\"clear:both;\"></div>";
            question.htmltrue += "</div>";
        }
        question.htmltrue += "</div>";
        question.htmltrue += "</div>";
        html += "</div>";
        html += "</div>";
        question.html = html;
        return question.html;
    }
    public string createChonLua(ArrayQuestion question)
    {
        ItemLuaChon item = question.itemLuaChon;
        item.content = item.content.Trim();
        Regex _reMath = new Regex("{(.+?)}");
        Regex _reNew = new Regex("[\n]?(.+?)\n[ ]?{.+?}");
        Regex _reMathDapAn = new Regex(@"\[(.+?)\]");
        string ID = createID();
        question.ID = ID;
        string html = "";
        item.arrayDapAn = new List<ItemChonLuaDapAn>();
        MatchCollection _matlAll = _reMath.Matches(item.content);
        MatchCollection _matlNew = _reNew.Matches(item.content);
        foreach (Match itemDapAn in _matlAll)
        {
            string fullRe = itemDapAn.Groups[0].Value;
            string dapan = itemDapAn.Groups[1].Value;
            item.content = Lib.ReplaceOne(item.content, fullRe, "<span class=\"panelChonCauDoan-Content-AddText\"><span class=\"panelChonCauDoan-Content-AddText-Num\">(" + (item.arrayDapAn.Count + 1) + ")</span></span>");
            string IDNew = createID();
            ItemChonLuaDapAn _objDapAn = new ItemChonLuaDapAn();
            _objDapAn.ID = IDNew;
            _objDapAn.item = new List<ItemChonLuaDapAnItem>();
            foreach (Match itemDAItem in _reMathDapAn.Matches(dapan))
            {
                string[] arrSplit = itemDAItem.Groups[1].Value.Split('-');
                _objDapAn.item.Add(new ItemChonLuaDapAnItem(arrSplit[0], arrSplit.Length >= 2 && Lib.isNumber(arrSplit[1]) ? Convert.ToBoolean(Convert.ToInt32(arrSplit[1])) : false, arrSplit.Length >= 3 ? arrSplit[2] : ""));
            }
            _objDapAn.numberChon = _objDapAn.item.Where(d => d.isChecked).ToArray().Length;
            _objDapAn.item = _objDapAn.item.OrderBy(d => Guid.NewGuid()).ToList();
            item.arrayDapAn.Add(_objDapAn);
        }

        html += "<div class=\"panelChonCauDoan\" valid=\"" + ID + "\" valtype=\"" + question.type + "\">";
        html += getTitleQuestion(item.title);
        if (_matlNew.Count != _matlAll.Count)
        {
            html += "<div class=\"panelChonCauDoan-Content\">" + item.content + "</div>";
        }
        if (_matlNew.Count != _matlAll.Count)
        {
            html += "<div class=\"panelChonCauDoan-ListItemSelect\">";
        }
        else
        {
            html += "<div class=\"panelChonCauDoan-ListItemSelect panelChonCauDoan-ListItemSelect-One\">";
        }
        int demCau = 0;
        question.htmltrue = html;
        foreach (ItemChonLuaDapAn itemShowDapAn in item.arrayDapAn)
        {
            demCau++;
            html += "<div class=\"panelChonCauDoan-ListItemSelect-Item\" valtext=\"\" valid=\"" + itemShowDapAn.ID + "\" valnumtrue=\"" + itemShowDapAn.numberChon + "\">";
            if (_matlNew.Count != _matlAll.Count)
            {
                html += "<span class=\"panelChonCauDoan-ListItemSelect-Item-Title\">" + demCau + "</span>";
            }
            else
            {
                html += "<span class=\"panelChonCauDoan-ListItemSelect-Item-Title\">" + demCau + ". " + _matlNew[demCau - 1].Groups[1].Value + "</span>";
            }
            question.htmltrue += "<div class=\"panelChonCauDoan-ListItemSelect-Item\" valtext=\"\" valid=\"" + itemShowDapAn.ID + "\" valnumtrue=\"" + itemShowDapAn.numberChon + "\">";
            question.htmltrue += "<span class=\"panelChonCauDoan-ListItemSelect-Item-Title\">" + demCau + "</span>";

            int numberItem = 0;
            foreach (ItemChonLuaDapAnItem itemData in itemShowDapAn.item)
            {
                string attr_giatich = "";
                if (!string.IsNullOrEmpty(itemData.giaithich))
                    attr_giatich = "attr-giaithich=\""+itemData.giaithich+"\"";
                html += "<span class=\"panelChonCauDoan-ListItemSelect-Item-ABCD\"  valtext=\"" + itemData.title + "\"><span class=\"panelChonCauDoan-ListItemSelect-Item-ABCD-Data\"><span class=\"panelChonCauDoan-ListItemSelect-Item-ABCD-Title\"><span></span>" + ((Convert.ToChar(numberItem + 65)).ToString()) + "</span><span class=\"panelChonCauDoan-ListItemSelect-Item-ABCD-Content\">" + itemData.title + "</span></span><div style=\"clear:both;\"></div></span>";
                if (!itemData.isChecked)
                    question.htmltrue += "<span " + attr_giatich + " class=\"panelChonCauDoan-ListItemSelect-Item-ABCD\" valtext=\"" + itemData.title + "\"><span class=\"panelChonCauDoan-ListItemSelect-Item-ABCD-Data\"><span class=\"panelChonCauDoan-ListItemSelect-Item-ABCD-Title\"><span></span>" + ((Convert.ToChar(numberItem + 65)).ToString()) + "</span><span class=\"panelChonCauDoan-ListItemSelect-Item-ABCD-Content\">" + itemData.title + "</span></span><div style=\"clear:both;\"></div></span>";
                else
                    question.htmltrue += "<span " + attr_giatich + " class=\"panelChonCauDoan-ListItemSelect-Item-ABCD\" valtext=\"" + itemData.title + "\"><span class=\"panelChonCauDoan-ListItemSelect-Item-ABCD-Data\"><span class=\"panelChonCauDoan-ListItemSelect-Item-ABCD-Title\"><span class=\"selectChonLuaDoan\"></span>" + ((Convert.ToChar(numberItem + 65)).ToString()) + "</span><span class=\"panelChonCauDoan-ListItemSelect-Item-ABCD-Content\">" + itemData.title + "</span></span><div style=\"clear:both;\"></div></span>";
                numberItem++;
            }
            html += "<div style=\"clear:both;\"></div>";
            html += "</div>";

            question.htmltrue += "<div style=\"clear:both;\"></div>";
            question.htmltrue += "</div>";
            //var arrGiaiThich = itemShowDapAn.item.Where(d => !string.IsNullOrEmpty(d.giaithich));
            //if (arrGiaiThich.Count() > 0) {
            //    question.htmltrue += "<div class=\"panelGiaiThich\">";
            //    foreach (ItemChonLuaDapAnItem itemGT in arrGiaiThich)
            //    {
            //        question.htmltrue += "<div>"+itemGT.title+"</div>";
            //    }
            //    question.htmltrue += "a</div>";
            //}
            
        }
        question.htmltrue += "</div>";

        

        question.htmltrue += "</div>";

        html += "</div>";
        html += "</div>";
        question.html = html;
        return question.html;
    }
    public string createPhanLoai(ArrayQuestion question)
    {
        ItemPhanLoai item = question.itemPhanLoai;
        List<string> dapAn = new List<string>();
        Regex _reSplit = new Regex("\n|\t\n");
        item.A = _reSplit.Split(item.content1).Where(d => !string.IsNullOrEmpty(d)).ToArray();
        item.B = _reSplit.Split(item.content2).Where(d => !string.IsNullOrEmpty(d)).ToArray();
        dapAn.AddRange(item.A);
        dapAn.AddRange(item.B);
        dapAn.OrderBy(d => Guid.NewGuid());
        string ID = createID();
        question.ID = ID;
        string html = "	<div class=\"panelPhanLoai\" mouse-move=\"false\" valid=\"" + ID + "\" valtype=\"" + question.type + "\">";
        html += getTitleQuestion(item.title);
        html += "	        <div class=\"panelPhanLoai-ArayItem\">";
        foreach (string itemDA in dapAn)
        {
            html += "	            <span class=\"panelPhanLoai-ArayItem-Item\" mouse-move=\"false\" valtext=\"" + itemDA + "\"><span>" + itemDA + "</span></span>";
        }
        question.htmltrue = html;

        question.htmltrue += "	        </div>";
        question.htmltrue += "	        <div class=\"panelPhanLoai-PanelPhanLoai\">";
        question.htmltrue += "	            <div class=\"panelPhanLoai-PanelPhanLoai-Left\" mouse-hover=\"false\">";
        question.htmltrue += "	                <div class=\"panelPhanLoai-PanelPhanLoai-Eff-AddText\"><span>Kéo đáp án vào đây</span></div>";
        question.htmltrue += "	                <div class=\"panelPhanLoai-PanelPhanLoai-Title\">";
        question.htmltrue += "	                    <span>" + item.title1 + "</span>";
        question.htmltrue += "	                </div>";
        question.htmltrue += "	                <div class=\"panelPhanLoai-PanelPhanLoai-AddData\">";
        for (int i = 0; i < dapAn.Count; i++)
        {
            if (item.A.Length > i)
                question.htmltrue += "<div valtext=\"" + item.A[i] + "\" class=\"panelPhanLoai-PanelPhanLoai-Item\">" + item.A[i] + "</div>";
            else
                question.htmltrue += "<div valtext=\"\" class=\"panelPhanLoai-PanelPhanLoai-Item\"></div>";
        }
        question.htmltrue += "	                </div>";
        question.htmltrue += "	            </div>";
        question.htmltrue += "	            <div class=\"panelPhanLoai-PanelPhanLoai-Right\" mouse-hover=\"false\">";
        question.htmltrue += "	                <div class=\"panelPhanLoai-PanelPhanLoai-Eff-AddText\"><span>Kéo đáp án vào đây</span></div>";
        question.htmltrue += "	                <div class=\"panelPhanLoai-PanelPhanLoai-Title\">";
        question.htmltrue += "	                    <span>" + item.title2 + "</span>";
        question.htmltrue += "	                </div>";
        question.htmltrue += "	                <div class=\"panelPhanLoai-PanelPhanLoai-AddData\">";
        for (int i = 0; i < dapAn.Count; i++)
        {
            if (item.B.Length > i)
                question.htmltrue += "<div valtext=\"" + item.B[i] + "\" class=\"panelPhanLoai-PanelPhanLoai-Item\">" + item.B[i] + "</div>";
            else
                question.htmltrue += "<div valtext=\"\" class=\"panelPhanLoai-PanelPhanLoai-Item\"></div>";
        }
        question.htmltrue += "	                </div>";
        question.htmltrue += "	            </div>";
        question.htmltrue += "	            <div style=\"clear:both;\"></div>";
        question.htmltrue += "	        </div>";
        question.htmltrue += "	    </div>";


        html += "	        </div>";
        html += "	        <div class=\"panelPhanLoai-PanelPhanLoai\">";
        html += "	            <div class=\"panelPhanLoai-PanelPhanLoai-Left\" mouse-hover=\"false\">";
        html += "	                <div class=\"panelPhanLoai-PanelPhanLoai-Eff-AddText\"><span>Kéo đáp án vào đây</span></div>";
        html += "	                <div class=\"panelPhanLoai-PanelPhanLoai-Title\">";
        html += "	                    <span>" + item.title1 + "</span>";
        html += "	                </div>";
        html += "	                <div class=\"panelPhanLoai-PanelPhanLoai-AddData\">";
        html += "	                </div>";
        html += "	            </div>";
        html += "	            <div class=\"panelPhanLoai-PanelPhanLoai-Right\" mouse-hover=\"false\">";
        html += "	                <div class=\"panelPhanLoai-PanelPhanLoai-Eff-AddText\"><span>Kéo đáp án vào đây</span></div>";
        html += "	                <div class=\"panelPhanLoai-PanelPhanLoai-Title\">";
        html += "	                    <span>" + item.title2 + "</span>";
        html += "	                </div>";
        html += "	                <div class=\"panelPhanLoai-PanelPhanLoai-AddData\"></div>";
        html += "	            </div>";
        html += "	            <div style=\"clear:both;\"></div>";
        html += "	        </div>";
        html += "	    </div>";

        question.html = html;
        return question.html;
    }
    public string createImage(ArrayQuestion question)
    {
        ItemImage item = question.itemImage;
        string ID = createID();
        question.ID = ID;
        string html = "";
        html += "<div class=\"panelImage\" mouse-move=\"false\" valid=\"" + ID + "\" valtype=\"" + question.type + "\">";
        html += getTitleQuestion(item.title);
        //////////////////////////////////////////////
        html += "<div class=\"panelImage-ArayItem\">";
        question.htmltrue = html;
        item.arrayPixel = item.arrayPixel.OrderBy(d => Guid.NewGuid()).ToList();
        foreach (ArrayPixel itemPixel in item.arrayPixel)
        {
            itemPixel.ID = createID();
            html += "<span class=\"panelImage-ArayItem-Item\" mouse-move=\"false\" valid=\"\" valtext=\"" + itemPixel.text + "\"><span>" + itemPixel.text + "</span></span>";
            question.htmltrue += "<span class=\"panelImage-ArayItem-Item\" mouse-move=\"false\" valid=\"" + itemPixel.ID + "\" valtext=\"" + itemPixel.text + "\"><span>" + itemPixel.text + "</span></span>";
        }
        question.htmltrue += "</div>";
        html += "</div>";
        //////////////////////////////////////////////
        question.htmltrue += "<div style=\"clear:both;height:20px;\"></div>";
        question.htmltrue += "<div class=\"panelImage-Data-Image\" style=\"background-image: url('images/upload/" + item.urlimage + "');height:" + item.height + "px;\" valwidth=\"" + item.width + "\">";

        html += "<div style=\"clear:both;height:20px;\"></div>";
        html += "<div class=\"panelImage-Data-Image\" style=\"background-image: url('images/upload/" + item.urlimage + "');height:" + item.height + "px;\" valwidth=\"" + item.width + "\">";
        foreach (ArrayPixel itemPixel in item.arrayPixel)
        {
            html += "<div valid=\"" + itemPixel.ID + "\" class=\"panelImage-Data-Image-ItemAdd\" valtext=\"\" mouse-hover=\"false\" style=\"left: " + itemPixel.offset.left + "px;top: " + itemPixel.offset.top + "px;\"><div class=\"throb\"></div></div>";
            question.htmltrue += "<div valid=\"" + itemPixel.ID + "\" class=\"panelImage-Data-Image-ItemAdd\" valtext=\"\" mouse-hover=\"false\" style=\"left: " + itemPixel.offset.left + "px;top: " + itemPixel.offset.top + "px;\"><div class=\"throb\"></div></div>";
        }
        question.htmltrue += "</div>";
        html += "</div>";
        //////////////////////////////////////////////
        question.htmltrue += "</div>";
        html += "</div>";
        question.html = html;
        return html;
    }
    public string createID()
    {
        List<string> arrayID = (List<string>)Session["Aray-ID-Struc-New"];
        string idCreate = Guid.NewGuid().ToString().Trim();
        while (arrayID.Contains(idCreate))
        {
            idCreate = Guid.NewGuid().ToString().Trim();
        }
        arrayID.Add(idCreate);
        Session["Aray-ID-Struc-New"] = arrayID;
        return idCreate;
    }
}