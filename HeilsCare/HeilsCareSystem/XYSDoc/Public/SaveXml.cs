using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using XYS.Remp.Screening.Model;

namespace XYS.Remp.Screening.Public
{
    public class SaveXml
    {
        //程序目录
        private static string _pathBase = System.AppDomain.CurrentDomain.BaseDirectory;

        private string dateName = Convert.ToDateTime(Properties.Settings.Default.ScreenDate)
            .ToString("yyyy-MM-dd", DateTimeFormatInfo.InvariantInfo);

        public SaveXml()
        {
            if (!Directory.Exists(_pathBase+@"\Data"))
            {
                Directory.CreateDirectory(_pathBase + @"\Data");
            }

            if (!File.Exists(_pathBase + @"\Data\" + dateName + ".xml"))
            {
                //创建xml文档对象
                XmlDocument xdoc = new XmlDocument();

                //创建第一行描述信息，并且添加到xdoc文档中
                XmlDeclaration xdec = xdoc.CreateXmlDeclaration("1.0", "utf-8", null);
                xdoc.AppendChild(xdec);
                //创建根节点
                XmlElement visitors=xdoc.CreateElement("Visitors");
                
                //将根节点添加到文档中
                xdoc.AppendChild(visitors);

                //xdoc.Save(_pathBase + @"Resources\Xml\SaveVisitor.xml");
                xdoc.Save(_pathBase + @"\Data\" + dateName + ".xml");
            }
        }

        public void AddXmlElement(string userName, IList<M_QuestionnaireResultDetail> questionnaireResultDetails)
        {
            //if (File.Exists(_pathBase + @"Resources\Xml\SaveVisitor.xml"))
            if (File.Exists(_pathBase + @"\Data\" + dateName + ".xml"))
            {
                //xml文档
                XmlDocument xmlDoc = new XmlDocument();
                //加载
                xmlDoc.Load(_pathBase + @"\Data\" + dateName + ".xml");
                //获取根节点
                XmlElement xmlRoot = xmlDoc.DocumentElement;
                //某个游客
                XmlElement xmlVisitor= xmlDoc.CreateElement("Visitor");

                //添加至根节点
                if (xmlRoot!=null)
                {
                    xmlRoot.AppendChild(xmlVisitor);
                }
                
                XmlElement xmluserName = xmlDoc.CreateElement("UserName");
                xmluserName.InnerText = userName;
                xmlVisitor.AppendChild(xmluserName);

                XmlElement questionList= xmlDoc.CreateElement("QuestionnaireResultDetailList");
                xmlVisitor.AppendChild(questionList);

                if (questionnaireResultDetails != null && questionnaireResultDetails.Count>0)
                {
                    //遍历集合
                    foreach (M_QuestionnaireResultDetail item in questionnaireResultDetails)
                    {
                        XmlElement questionDetail = xmlDoc.CreateElement("QuestionnaireResultDetail");
                        questionList.AppendChild(questionDetail);

                        XmlElement xmlResult = xmlDoc.CreateElement("QuestionResult");
                        xmlResult.InnerText = item.QuestionResult;
                        questionDetail.AppendChild(xmlResult);

                        XmlElement xmlCode = xmlDoc.CreateElement("QuestionCode");
                        xmlCode.InnerText = item.QuestionCode;
                        questionDetail.AppendChild(xmlCode);

                        XmlElement xmlType= xmlDoc.CreateElement("QuestionType");
                        xmlType.InnerText = item.QuestionType.ToString();
                        questionDetail.AppendChild(xmlType);
                    }
                }

                //xmlDoc.Save(_pathBase + @"Resources\Xml\SaveVisitor.xml");
                xmlDoc.Save(_pathBase + @"\Data\" + dateName + ".xml");
            }
        }
    }
}
