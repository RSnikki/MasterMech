using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MasterMechLib;
namespace MasterMech
{
    public partial class PrintInvoiceForm : Form
    {
        public int mnInvoiceSNo;
        public PrintInvoiceForm()
        {
            InitializeComponent();
        }

        public PrintInvoiceForm(int inInvoiceSNo)
        {
            mnInvoiceSNo = inInvoiceSNo;
            InitializeComponent();
        }

        private void PrintInvoiceForm_Load(object sender, EventArgs e)
        {
            Invoice lObjInvoiceDummy = new Invoice(MasterMechUtil.msConString, MasterMechUtil.sUserID);
            lObjInvoiceDummy.Load(mnInvoiceSNo);
            PreparePrintPreview(lObjInvoiceDummy);
        }

        public void PreparePrintPreview(Invoice iObjInvoice)
        {
            int lnCnt = 1;
            string lsPath = "";
            lsPath = System.DateTime.Now.ToString("dd-MMM-yyyy");
            lsPath += System.DateTime.Now.Hour.ToString();
            lsPath += System.DateTime.Now.Minute.ToString();
            lsPath += System.DateTime.Now.Second.ToString();

            StreamWriter sw;
            sw = File.CreateText(Application.StartupPath + "\\InVoice_" + lsPath + ".html");
            sw.WriteLine("<html>");
            sw.WriteLine("<body>");
            sw.WriteLine("<fieldset>");
            sw.WriteLine("<fieldset>");
            sw.WriteLine("<header>");
            sw.WriteLine("<h1>" + MasterMechUtil.BusinessName + "</h1>");
            sw.WriteLine("<h4>" + MasterMechUtil.BusinessAddress + "</h4>");
            sw.WriteLine("<h4>GSTIN-" + MasterMechUtil.BusinessGST + "</h4>");
            sw.WriteLine("</header>");
            sw.WriteLine("</fieldset>");

            sw.WriteLine("<br/>");
            sw.WriteLine("<br/>");

            sw.WriteLine("<fieldset>");
            sw.WriteLine("<section>");
            sw.WriteLine("<p>To</p>");
            sw.WriteLine("</section>");
            sw.WriteLine("<aside>");
            sw.WriteLine("<p>"+ iObjInvoice.InvoiceCustomer.msCustomerFName + " " + iObjInvoice.InvoiceCustomer.msCustomerLName + "</p >");
            sw.WriteLine("<p>Mob. No: " + iObjInvoice.InvoiceCustomer.msCustomerMNo + "</p>");
            sw.WriteLine("<p>Email Id: " + iObjInvoice.InvoiceCustomer.msCustomerEmail + "</p>");
            sw.WriteLine("<p>Address: </p>");
            sw.WriteLine(iObjInvoice.InvoiceCustomer.msCustomerStAddr + " " + iObjInvoice.InvoiceCustomer.msCustomerArAddr + "<br/>");
            sw.WriteLine(iObjInvoice.InvoiceCustomer.msCustomerCity + " " + iObjInvoice.InvoiceCustomer.msCustomerState + "<br/>");
            sw.WriteLine(iObjInvoice.InvoiceCustomer.msCustomerState + "-" + iObjInvoice.InvoiceCustomer.msCustomerPinCode + "<br/>");
            sw.WriteLine("GST No.: " + iObjInvoice.InvoiceCustomer.msCustomerGSTNo + "<br/>");
            sw.WriteLine("</aside>");
            sw.WriteLine("</fieldset>");

            sw.WriteLine("<fieldset>");
            sw.WriteLine("<section>");
            sw.WriteLine("<p>Invoice No.: " + iObjInvoice.mnInvoiceSNo + "</p>");
            sw.WriteLine("<p>Invoice Date: " + iObjInvoice.mdInvoiceDate + "</p>");
            sw.WriteLine("</section>");
            sw.WriteLine("</fieldset>");

            sw.WriteLine("<fieldset>");
            sw.WriteLine("<table border = \"1.0 solid\" color = \"black\"  style =\"width : 100%\">");
            sw.WriteLine("<thead>");
            sw.WriteLine("<tr>");
            sw.WriteLine("<th>");
            sw.WriteLine("SNo");//1
            sw.WriteLine("</th>");
            sw.WriteLine("<th>");
            sw.WriteLine("Item");//2
            sw.WriteLine("</th>");
            sw.WriteLine("<th>");
            sw.WriteLine("Unit of Meas.");//3
            sw.WriteLine("</th>");
            sw.WriteLine("<th>");
            sw.WriteLine("Unit Price");//4
            sw.WriteLine("</th>");
            sw.WriteLine("<th>");
            sw.WriteLine("Quantity");//5
            sw.WriteLine("</th>");
            sw.WriteLine("<th>");
            sw.WriteLine("Discount");//6
            sw.WriteLine("</th>");
            sw.WriteLine("<th>");
            sw.WriteLine("CGST Amount");//7
            sw.WriteLine("</th>");
            sw.WriteLine("<th>");
            sw.WriteLine("SGST Amount");//8
            sw.WriteLine("</th>");
            sw.WriteLine("<th>");
            sw.WriteLine("IGST Amount");//9
            sw.WriteLine("</th>");
            sw.WriteLine("<th>");
            sw.WriteLine("Tax");//10
            sw.WriteLine("</th>");
            sw.WriteLine("<th>");
            sw.WriteLine("Total Amount");//11
            sw.WriteLine("</th>");
            sw.WriteLine("</tr>");
            sw.WriteLine("</thead>");

            sw.WriteLine("<tbody>");
            foreach (InvoiceItem lineItem in iObjInvoice.InvoiceItems)
            {
                sw.WriteLine("<tr>");

                sw.WriteLine("<td>" + (lnCnt++) + "</td>"); //1
                
                sw.WriteLine("<td>" + lineItem.msItemDesc + "</td>"); //2

                sw.WriteLine("<td>" + ((lineItem.msItemUOM is null) ? "&nbsp" : lineItem.msItemUOM) + "</td>"); //3


                sw.WriteLine("<td>" + lineItem.mnItemPrice   + "</td>"); //4
                
                sw.WriteLine("<td>" + ((lineItem.mnQty is null)? 0 : lineItem.mnQty) + "</td>"); //5
                
                sw.WriteLine("<td>" + ((lineItem.mnDiscountAmount is null) ? 0 : lineItem.mnDiscountAmount) + "</td>"); //6
                
                sw.WriteLine("<td>" + ((lineItem.mnCGSTAmount is null) ? 0 : lineItem.mnCGSTAmount) + "</td>"); //7
                
                sw.WriteLine("<td>" + ((lineItem.mnSGSTAmount is null) ? 0 : lineItem.mnSGSTAmount) + "</td>"); //8
                
                sw.WriteLine("<td>" + ((lineItem.mnIGSTAmount is null) ? 0 : lineItem.mnIGSTAmount) + "</td>"); //9

                double? calTax = ((lineItem.mnCGSTAmount is null) ? 0 : lineItem.mnCGSTAmount) + ((lineItem.mnSGSTAmount is null) ? 0 : lineItem.mnSGSTAmount) + ((lineItem.mnIGSTAmount is null) ? 0 : lineItem.mnIGSTAmount);


                sw.WriteLine("<td>" + calTax + "</td>"); //10
                
                sw.WriteLine("<td>" + lineItem.mnTotalAmount + "</td>"); //11
                
                sw.WriteLine("</tr>");
            }
            sw.WriteLine("<tr>");
            sw.WriteLine("<td colspan = \"10\">" + "Net Total" + "</td>");
            sw.WriteLine("<td>" + (((iObjInvoice.mnPartsTotal is null) ? 0 : iObjInvoice.mnPartsTotal) + ((iObjInvoice.mnLabourTotal is null) ? 0 : iObjInvoice.mnLabourTotal)) + "</td>");
            sw.WriteLine("</tr>");

            sw.WriteLine("<tr>");
            sw.WriteLine("<td colspan = \"10\">" + "Total Discount" + "</td>");
            sw.WriteLine("<td>" + ((iObjInvoice.mnDiscountAmount is null) ? 0 : iObjInvoice.mnDiscountAmount) + "</td>");
            sw.WriteLine("</tr>");

            sw.WriteLine("<tr>");
            sw.WriteLine("<td colspan = \"10\">" + "Total Gross" + "</td>");
            sw.WriteLine("<td>" + iObjInvoice.mnGrandTotal + "</td>");
            sw.WriteLine("</tr>");

            sw.WriteLine("<tr>");
            sw.WriteLine("<td colspan = \"10\">" + "Total Tax" + "</td>");
            sw.WriteLine("<td>" + iObjInvoice.mnTotalTax + "</td>");
            sw.WriteLine("</tr>");

            sw.WriteLine("<tr>");
            sw.WriteLine("<td colspan = \"10\">" + "Invoice Total" + "</td>");
            sw.WriteLine("<td>" + iObjInvoice.mnInvoiceTotal + "</td>");
            sw.WriteLine("</tr>");

            sw.WriteLine("</tbody>");
            sw.WriteLine("</table>");
            sw.WriteLine("</fieldset>");

            sw.WriteLine("<br/>");
            sw.WriteLine("<br/>");
            sw.WriteLine("</fieldset>");
            sw.WriteLine("</body>");
            sw.WriteLine("</html>");
            sw.Close();
            webBrowserInvoicePrint.Navigate(Application.StartupPath + "\\InVoice_" + lsPath + ".html");

        }

        private void buttonPrint_Click(object sender, EventArgs e)
        {
            webBrowserInvoicePrint.Print();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
