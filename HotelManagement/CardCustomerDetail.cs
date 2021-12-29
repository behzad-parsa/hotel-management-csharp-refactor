using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
namespace HotelManagement
{
    public partial class CardCustomerDetail : UserControl
    {
        Dictionary<BunifuMetroTextbox, string> txtBoxList = new Dictionary<BunifuMetroTextbox, string>();
        BunifuImageButton btnNext;
        BunifuImageButton btnBack;
        Panel panelContainerInside;
        BunifuImageButton btnDone;
        //List<BunifuMetroTextbox> lstOriginalTextBox = new List<BunifuMetroTextbox>();
        //List<BunifuMetroTextbox> lstCurrentTextBox = new List<BunifuMetroTextbox>();
        public CardCustomerDetail()
        {
            InitializeComponent();


        }
        public CardCustomerDetail(CustomerSecond customer)
        {
            InitializeComponent();


            ActID = customer.ActID;
            txtFname.Text = customer.Firstname;
            txtLname.Text = customer.Lastname;
            txtTel.Text = customer.Tel;
            txtMobile.Text = customer.Mobile;
            txtCity.Text = customer.City;
            txtAddress.Text = customer.Address;
            txtEmail.Text = customer.Email;
            txtNCSearch.Text = customer.NationalCode;
            cmbNational.SelectedItem = customer.Nationality;
            cmbState.SelectedItem = customer.State;
            
            if (customer.Gender == "Male") rdbMale.Checked = true;
            else rdbFemale.Checked = true;

            dateBirth.Value = customer.Birthday;


        }
        private void CardCustomerDetail_Load(object sender, EventArgs e)
        {
            panelContainerInside = (this.Parent.Parent as NewBook).Controls["panelContainerInside"] as Panel;
            btnNext = (this.Parent.Parent as NewBook).Controls["btnNext"] as BunifuImageButton;
            //btnEdit = (this.Parent.Parent as NewBook).Controls["btnEdit"] as BunifuImageButton;
            //panelCustLeft.Enabled = false;
           // panelCustRight.Enabled = false;
            btnCustSubmit.Enabled = false;
            btnBack = (this.Parent.Parent as NewBook).Controls["btnBack"] as BunifuImageButton;
            btnBack.Visible = false ;
            btnDone = (this.Parent.Parent as NewBook).Controls["btnDone"] as BunifuImageButton;
            btnDone.Visible = false;
            //foreach (Control control in bunifuCards1.Controls )
            //{
            //    if (control is BunifuMetroTextbox)
            //        // You can check any other property here and do what you want
            //        // for example:
            //        lstOriginalTextBox.Add(control as BunifuMetroTextbox);
            //    //Action
            //}
            //foreach (Control control in panelCustLeft.Controls)
            //{
            //    if (control is BunifuMetroTextbox)
            //        // You can check any other property here and do what you want
            //        // for example:
            //        lstOriginalTextBox.Add(control as BunifuMetroTextbox);
            //    //Action
            //}
            //foreach (Control control in panelCustRight.Controls)
            //{
            //    if (control is BunifuMetroTextbox)
            //        // You can check any other property here and do what you want
            //        // for example:
            //        lstOriginalTextBox.Add(control as BunifuMetroTextbox);
            //    //Action
            //}
            cmbNational.SelectedIndex = 0;
            cmbState.SelectedIndex =0 ;
            dateBirth.Value = DateTime.Now;
            //var allTexboxes = panelCustLeft.Controls.OfType<BunifuMetroTextbox>();
            //lstTextBox = allTexboxes.ToList<BunifuMetroTextbox>();
        }
        
        //private int customerID;
        private enum Status
        {
            Green,
            Red,
            blue
        };
        //private void PanelStatus(string text, Status status)
        //{
        //    panelCustStatus.Visible = true;
        //    lblCustError.Text = text;
        //    if (status == Status.Red)
        //    {
        //        prgbCustError.ProgressColor = Color.Red;
        //        lblCustError.ForeColor = Color.Red;
        //        //lblCustError.Text = text;

        //    }
        //    else if (status == Status.Green)
        //    {

        //        prgbCustError.ProgressColor = Color.Green;
        //        lblCustError.ForeColor = Color.Green;
        //        //lblCustError.Text = text;

        //    }
        //    else
        //    {
        //        prgbCustError.ProgressColor = Color.Blue;
        //        lblCustError.ForeColor = Color.Blue;

        //    }




        //}

        private void TextBoxColor(BunifuMetroTextbox txtBox, Status status)
        {
            if (status == Status.Red)
            {
                txtBox.BorderColorIdle = Color.Red;


            }
            else if (status == Status.Green)
            {

                txtBox.BorderColorIdle = Color.FromArgb(231, 228, 228);
            }
            else
            {
                txtBox.BorderColorIdle = Color.FromArgb(128, 128, 128);
            }

        }
        private bool TextBoxCheck(BunifuMetroTextbox txtBox , string txt)
        {
            if (txtBox.Text == txt || txtBox.Text == "")
            {
                TextBoxColor(txtBox, Status.Red);
                return false;
            }
            //else if(txt == "National Code")
            //{
            //    TextBoxColor(txtBox, Status.blue);
            //    txtCount++;
            //    return true;
            //}
            else
            {
                TextBoxColor(txtBox, Status.Green);
                txtCount++;
                return true;
                
            }
        }
        private static int txtCount = 0;
        private bool ValidationFlag = false;
        private bool isFindCutomerFlag = false;
        private void btnCustSubmit_Click_1(object sender, EventArgs e)
        {
            
            /////---------Validation-------------
            //TextBoxCheck(txtCustFname , "Firstname");
            //TextBoxCheck(txtCustLname, "Lastname");
            //TextBoxCheck(txtCustMobile, "Mobile Phone");
            //TextBoxCheck(txtCustNationalCode, "National Code");
            //TextBoxCheck(txtCustCity, "City");
            //TextBoxCheck(txtCustEmail, "Email");
            //TextBoxCheck(txtCustAddress, "Address");
            //TextBoxCheck(txtCustTel, "Home Phone");

            //if (txtCount == 8)
            //{
            //    if (dateCustBirth.Value.Date != DateTime.Now.Date)
            //    {

            //        panelCustStatus.Visible = false;
            //        ValidationFlag = true;


            //    }
            //    else
            //    {
            //        PanelStatus("Choose Birthday", Status.Red);

            //    }

                



            //}
            //else
            //{
                
            //    PanelStatus("Please Fill The Blank", Status.Red);
            //}
            //txtCount = 0;



            //if (ValidationFlag)
            //{
            //    ValidationFlag = false;
            //    if (!isFindCutomerFlag)
            //    {
            //        var result = HotelDatabase.Actor.InsertAll(txtCustFname.Text, txtCustLname.Text, dateCustBirth.Value.Date,
            //      txtCustNationalCode.Text, cmbCustNational.SelectedItem.ToString(), txtCustEmail.Text, txtCustTel.Text,
            //      txtCustMobile.Text, RadioButtonResult(rdbCustMale, rdbCustFemale), cmbCustState.SelectedItem.ToString(), txtCustCity.Text, txtCustAddress.Text);
            //        if (result > 0)
            //        {

            //            var resultCustomer = HotelDatabase.Customer.Insert(result);
            //            if (resultCustomer >0)
            //            {
            //                NewBook.currentCustomerID = resultCustomer;
            //                PanelStatus("Action Completed Successfuly", Status.Green);
            //                NewBook.statusFlag = 1;
            //                btnCustSubmit.Enabled = false;
            //                btnNext.Visible = true;

            //                Customer customerInfo = new Customer(txtCustFname.Text, txtCustLname.Text, txtCustNationalCode.Text, txtCustMobile.Text ,  dateCustBirth.Value.Date,
            //                     RadioButtonResult(rdbCustMale, rdbCustFemale) ,  cmbCustNational.SelectedItem.ToString(), txtCustEmail.Text, txtCustTel.Text
            //                      , cmbCustState.SelectedItem.ToString(), txtCustCity.Text, txtCustAddress.Text);
            //                NewBook.customerInfo = customerInfo;



            //            }
            //            else
            //            {
            //                PanelStatus("Unable to Complete Action - Customer Exist Already - Just Search Again", Status.Red);
            //            }


                        

                        
                        



            //        }
            //        else
            //        {
            //            PanelStatus("Unable to Complete Action - National Code Exist Already", Status.Red);
            //        }



            //    }
            //    else if (isFindCutomerFlag)
            //    {

            //        var resultCustomer = HotelDatabase.Customer.Insert(HotelDatabase.Actor.ID);
            //        if (resultCustomer > 0)
            //        {
            //            NewBook.currentCustomerID = resultCustomer;
            //            PanelStatus("Action Completed Successfuly", Status.Green);
            //            NewBook.statusFlag = 1;
            //            btnCustSubmit.Enabled = false;
            //            btnNext.Visible = true;
            //            isFindCutomerFlag = false;
            //        }
            //        else
            //        {
            //            PanelStatus("Unable to Complete Action - Customer Exist Already - Just Search Again", Status.Red);
            //        }





            //    }
            //    else
            //    {

            //    }
                    
              


            //}


      


        }
        private void btnCustSearch_Click(object sender, EventArgs e)
        {

            //txtCustNationalCode.Focus();
            //panelCustStatusWaiting.Visible = true;


            //TextBoxClearBorderColor();
            ////TextBoxClearText();

            //if (txtCustNationalCode.Text != "National Code" && txtCustNationalCode.Text != "")
            //{
            //    if (HotelDatabase.Actor.SearchActor(txtCustNationalCode.Text))
            //    {

                    
                    

            //        isFindCutomerFlag = true;

                   
            //        panelCustLeft.Enabled = false;
            //        panelCustRight.Enabled = false;
            //        btnCustSubmit.Enabled = false;
            //        btnNext.Visible = true;
            //        NewBook.statusFlag = 1;
            //        //NewBook.currentCustomerID = HotelDatabase.Actor.ID;
            //        PanelStatus("Customer Was successfully Found", Status.Green);


            //        txtCustFname.Text = HotelDatabase.Actor.Firstname;
            //        txtCustLname.Text = HotelDatabase.Actor.Lastname;
            //        txtCustEmail.Text = HotelDatabase.Actor.Email;
            //        txtCustMobile.Text = HotelDatabase.Actor.Mobile;
            //        txtCustNationalCode.Text = HotelDatabase.Actor.NationalCode;
            //        txtCustTel.Text = HotelDatabase.Actor.Tel;
            //        txtCustCity.Text = HotelDatabase.Actor.City;
            //        txtCustAddress.Text = HotelDatabase.Actor.Address;
            //        dateCustBirth.Value = HotelDatabase.Actor.Birthday.Date; //Min Value As Null
            //        cmbCustNational.SelectedItem = HotelDatabase.Actor.Nationality;
            //        cmbCustState.SelectedItem = HotelDatabase.Actor.State;
            //        if (HotelDatabase.Actor.Gender == "Male") rdbCustMale.Checked = true;
            //        else rdbCustFemale.Checked = true;




            //        int resultCustomer = HotelDatabase.Customer.Insert(HotelDatabase.Actor.ID);
            //        if (resultCustomer > 0)
            //        {
            //            NewBook.currentCustomerID = resultCustomer;

            //        }
            //        else
            //        {
            //            NewBook.currentCustomerID = HotelDatabase.Customer.SearchCustomerID(HotelDatabase.Actor.ID);
            //        }





            //        Customer customerInfo = new Customer(txtCustFname.Text, txtCustLname.Text, txtCustNationalCode.Text, txtCustMobile.Text, dateCustBirth.Value.Date,
            //                   RadioButtonResult(rdbCustMale, rdbCustFemale), cmbCustNational.SelectedItem.ToString(), txtCustEmail.Text, txtCustTel.Text
            //                    , cmbCustState.SelectedItem.ToString(), txtCustCity.Text, txtCustAddress.Text);
            //        NewBook.customerInfo = customerInfo;





            //        // panelCustStatusWaiting.Visible = false;
            //    }
            //    else
            //    {
            //        PanelStatus("No Person found", Status.Red);
            //        TextBoxClearText();
            //        btnCustSubmit.Enabled = true;
            //        panelCustLeft.Enabled = true;
            //        panelCustRight.Enabled = true;
            //        btnNext.Visible = false;
            //        isFindCutomerFlag = false;
            //    }
            //}
            //else
            //{
            //    PanelStatus("Enter National Code", Status.Red);
            //    TextBoxColor(txtCustNationalCode, Status.Red);
            //}

            //// pgbCust.Visible = false;
            ////lblCustWaiting.Visible = false;

            //panelCustStatusWaiting.Visible = false;
        }

        private void PanelStatus(Control Panel, string text, Status status)
        {
            BunifuCircleProgressbar prgb = null;
            BunifuCustomLabel lbl = null;
            Panel.Visible = true;
            foreach (Control item in Panel.Controls)
            {
                if (item is BunifuCustomLabel)
                {
                    lbl = item as BunifuCustomLabel;

                }
                else
                {
                    prgb = item as BunifuCircleProgressbar;

                }

            }

            lbl.Text = text;
            if (status == Status.Red)
            {
                prgb.ProgressColor = Color.Red;
                lbl.ForeColor = Color.Red;


            }
            else if (status == Status.Green)
            {

                prgb.ProgressColor = Color.Green;
                lbl.ForeColor = Color.Green;


            }
            else
            {
                prgb.ProgressColor = Color.Blue;
                lbl.ForeColor = Color.Blue;

            }




        }

        private void TextBoxEnter(object sender, EventArgs e)
        {
            var txtBox = sender as BunifuMetroTextbox;
            if (txtBox != txtNCSearch)
            {
                txtBox.BorderColorIdle = Color.FromArgb(231, 228, 228);

            }
           
            txtBox.ForeColor = Color.Black;
            if (!txtBoxList.ContainsKey(txtBox))
            {
                txtBoxList.Add(txtBox, txtBox.Text);
            }
            txtBoxList.TryGetValue(txtBox, out string defualtText);
            if (txtBox.Text == defualtText)
            {
                txtBox.Text = null;
            }


        }
        private void TextBoxLeave(object sender, EventArgs e)
        {
            var txtBox = sender as BunifuMetroTextbox;

            if (txtBox.Text == null || txtBox.Text == "")
            {
                txtBoxList.TryGetValue(txtBox, out string defualtText);
                txtBox.Text = defualtText;
                txtBox.ForeColor = Color.Gray;
            }


        }
        private string RadioButtonResult(RadioButton rdb1, RadioButton rdb2)
        {
            if (rdb1.Checked)
            {
                return rdb1.Text;
            }
            else
            {
                return rdb2.Text;
            }
        }

        private void Reset()
        {
            txtFname.Text = "Firstname";
            txtFname.ForeColor = Color.Gray;

            txtLname.Text = "Lastname";
            txtLname.ForeColor = Color.Gray;

            txtMobile.Text = "Mobile Phone";
            txtMobile.ForeColor = Color.Gray;

            txtCity.Text = "City";
            txtCity.ForeColor = Color.Gray;

            txtEmail.Text = "Email";
            txtEmail.ForeColor = Color.Gray;

            txtAddress.Text = "Address";
            txtAddress.ForeColor = Color.Gray;
        
            txtTel.Text = "Home Phone";
            txtTel.ForeColor = Color.Gray;

            dateBirth.Value = DateTime.Now.Date;

            panelStatusCustomer.Visible = false;

            TextBoxClearBorderColor();

            isFindActor = false;
            isFindCustomer = false;
            //ChbUpdate(false);

            btnNext.Visible = false;

            btnSubmit.Enabled = true;


            panelBasic.Enabled = false;
            panelContact.Enabled = false;


            panelUpdate.Visible = false;
            updateFlag = false;
           // ActID = -10;
            //EmployeeID = -10;

        }
      
        private void TextBoxClearBorderColor()
        {

            TextBoxColor(txtFname, Status.Green);
            TextBoxColor(txtLname, Status.Green);
            TextBoxColor(txtMobile, Status.Green);
            //TextBoxColor(txtNationalCode, Status.blue);
            TextBoxColor(txtCity, Status.Green);
            TextBoxColor(txtEmail, Status.Green);
            TextBoxColor(txtAddress, Status.Green);
            TextBoxColor(txtTel, Status.Green);

        }

      

        //private void txtCustNationalCode_OnValueChanged(object sender, EventArgs e)
        //{
        //    //panelCustStatus.Visible = false;    
        //}

        private bool searchFlag = false;
        private bool isFindActor = false;
        private bool isFindCustomer = true;
        private int CustomerID = -1;
        private int ActID = -1;
        private void btnNCSearch_Click(object sender, EventArgs e)
        {
            //panelStatusEmployee.Visible = false;
            Reset();

            if (txtNCSearch.Text != "National Code" && txtNCSearch.Text != "")
            {
                searchFlag = true;

                if (HotelDatabase.Actor.SearchActor(txtNCSearch.Text))
                {
                    isFindActor = true;

                    ActID = HotelDatabase.Actor.ID;
                    txtFname.Text = HotelDatabase.Actor.Firstname;
                    txtLname.Text = HotelDatabase.Actor.Lastname;
                    txtTel.Text = HotelDatabase.Actor.Tel;
                    txtMobile.Text = HotelDatabase.Actor.Mobile;
                    txtCity.Text = HotelDatabase.Actor.City;
                    txtAddress.Text = HotelDatabase.Actor.Address;
                    txtEmail.Text = HotelDatabase.Actor.Email;
                    cmbNational.SelectedItem = HotelDatabase.Actor.Nationality;
                    cmbState.SelectedItem = HotelDatabase.Actor.State;

                    if (HotelDatabase.Actor.Gender == "Male") rdbMale.Checked = true;
                    else rdbFemale.Checked = true;

                    dateBirth.Value = HotelDatabase.Actor.Birthday;

                    var result = HotelDatabase.Customer.SearchCustomerID(ActID);
                    //Person Was not in Customer Table
                    if (result == -1 )
                    {


                        isFindCustomer = false;
                        
                        PanelStatus(panelStatusCustomer, "Person Was successfully Found", Status.Green);
                        //ChbUpdate(true);
                        //panelBasic.Enabled = true;
                        //panelContact.Enabled = true;
                        //btnSubmit.Enabled = true;
                        // btnEdit.Enabled = true;
                        //btnNext.Enabled = false;
                        btnSubmit.Enabled = true;
                        




                    }
                    //Person Is In Customer Table
                    else if (result > 0)
                    {

                        PanelStatus(panelStatusCustomer, "Customer Was Successfully Found", Status.Green);
                        isFindCustomer = true;
                        CustomerID = HotelDatabase.Customer.ID;
                        // ChbUpdate(false);
                        //panelBasic.Enabled = false;
                        //panelContact.Enabled = false;
                        // btnSubmit.Enabled = false;
                        //btnNext.Enabled = true;
                        // btnEdit.Enabled = true;
                        btnSubmit.Enabled = false;
                        btnNext.Visible = true;

                        CustomerSecond customer = new CustomerSecond(CustomerID, ActID, HotelDatabase.Actor.Firstname, HotelDatabase.Actor.Lastname, HotelDatabase.Actor.NationalCode,
                            HotelDatabase.Actor.Mobile, HotelDatabase.Actor.Birthday, HotelDatabase.Actor.Gender, HotelDatabase.Actor.Nationality,
                            HotelDatabase.Actor.Email, HotelDatabase.Actor.Tel, HotelDatabase.Actor.State, HotelDatabase.Actor.City, HotelDatabase.Actor.Address);

                        NewBook.customerInfo = customer;
                        NewBook.statusFlag = 1;



                    
                    }
                    //Exception
                    else
                    {
                        PanelStatus(panelStatusCustomer, "Unable To Complete Action", Status.Green);
                    }







                }
                else
                {
                    //panelInfo.Enabled = false;
                    isFindActor = false;
                   // isFindEmployee = false;
                    Reset();
                    panelBasic.Enabled = true;
                    panelContact.Enabled = true;
                    //panelEmployment.Enabled = true;
                    PanelStatus(panelStatusCustomer, "No Person Found", Status.Red);
                }






            }

        }

        private void btnSubmit_Click_1(object sender, EventArgs e)
        {

            if (searchFlag && !isFindActor)
            {


                TextBoxCheck(txtFname, "Firstname");
                TextBoxCheck(txtLname, "Lastname");
                TextBoxCheck(txtMobile, "Mobile Phone");
                //TextBoxCheck(txtCustNationalCode, "National Code");
                TextBoxCheck(txtCity, "City");
                TextBoxCheck(txtEmail, "Email");
                TextBoxCheck(txtAddress, "Address");
                TextBoxCheck(txtTel, "Home Phone");

                if (txtCount == 7 && txtNCSearch.Text != "" && txtNCSearch.Text != "National Code")
                {
                    if (dateBirth.Value.Date != DateTime.Now.Date)
                    {

                        //panelCustStatus.Visible = false;
                        ValidationFlag = true;


                    }
                    else
                    {
                        PanelStatus(panelStatusCustomer  , "Please Choose Birthday", Status.Red);

                    }





                }
                else
                {

                    PanelStatus(panelStatusCustomer ,  "Please Fill The Blank", Status.Red);
                }
                txtCount = 0;



                if (ValidationFlag)
                {
                    ValidationFlag = false;

                    var result = HotelDatabase.Actor.InsertAll(txtFname.Text, txtLname.Text, dateBirth.Value.Date,
                     txtNCSearch.Text, cmbNational.SelectedItem.ToString(), txtEmail.Text, txtTel.Text,
                     txtMobile.Text, RadioButtonResult(rdbMale, rdbFemale), cmbState.SelectedItem.ToString(), txtCity.Text, txtAddress.Text);
                    if (result > 0)
                    {
                        ActID = result;
                        var resultCustomer = HotelDatabase.Customer.Insert(result);
                        if (resultCustomer > 0)
                        {
                            CustomerID = resultCustomer;
                            //NewBook.currentCustomerID = resultCustomer;
                            PanelStatus(panelStatusCustomer , "Action Completed Successfuly", Status.Green);
                            Current.User.Activities.Add(new Activity("Submit New Customer", txtFname.Text + " " + txtLname.Text + "'s information has been submited by " + Current.User.Firstname+" " +Current.User.Lastname));

                            //NewBook.statusFlag = 1;
                            //btnCustSubmit.Enabled = false;
                            btnNext.Visible = true;
                            btnSubmit.Enabled = false;

                            panelBasic.Enabled = false;
                            panelContact.Enabled = false;


                            CustomerSecond customer = new CustomerSecond(CustomerID , ActID , txtFname.Text, txtLname.Text, txtNCSearch.Text, txtMobile.Text, dateBirth.Value.Date,
                                 RadioButtonResult(rdbMale, rdbFemale), cmbNational.SelectedItem.ToString(), txtEmail.Text, txtTel.Text
                                 , cmbState.SelectedItem.ToString(), txtCity.Text, txtAddress.Text);



                            NewBook.customerInfo = customer;
                            NewBook.statusFlag = 1;

                            //NewBook.customerInfo = customerInfo;



                        }
                        else
                        {
                            PanelStatus( panelStatusCustomer, "Unable to Complete Action - Customer Exist Already", Status.Red);
                        }

                    }
                    else
                    {
                        PanelStatus(panelStatusCustomer , "Unable to Complete Action - National Code Exist Already", Status.Red);
                    }            

                }


            }
            else if (isFindActor)
            {

                if (updateFlag)
                {
                    
                    var reslut = HotelDatabase.Actor.UpdateAll(ActID, txtFname.Text, txtLname.Text, dateBirth.Value.Date , txtNCSearch.Text,
                            cmbNational.SelectedItem.ToString(), txtEmail.Text,   txtTel.Text, txtMobile.Text ,
                            RadioButtonResult(rdbMale, rdbFemale), cmbState.SelectedItem.ToString(), txtCity.Text, txtAddress.Text);

                    if (reslut)
                    {
                        updateFlag = false;
                        PanelStatus(panelStatusCustomer, "Information Changed Successfuly", Status.Green);
                        Current.User.Activities.Add(new Activity("Edit Customer Information", txtFname.Text + " " + txtLname.Text + "'s information has been changed by " + Current.User.Firstname + " " + Current.User.Lastname));

                        btnSubmit.Text = "Submit";

                        if (isFindCustomer)
                        {
                            btnSubmit.Enabled = false;
                            CustomerSecond customer = new CustomerSecond(CustomerID, ActID, txtFname.Text, txtLname.Text, txtNCSearch.Text, txtMobile.Text, dateBirth.Value.Date,
                                RadioButtonResult(rdbMale, rdbFemale), cmbNational.SelectedItem.ToString(), txtEmail.Text, txtTel.Text
                                , cmbState.SelectedItem.ToString(), txtCity.Text, txtAddress.Text);

                            NewBook.customerInfo = customer;
                            NewBook.statusFlag = 1;

                        }
                        panelBasic.Enabled = false;
                        panelContact.Enabled = false;

                        panelUpdate.Visible = false;
                        //Customer customer = new Customer(CustomerID, ActID, txtFname.Text, txtLname.Text, txtNCSearch.Text, txtMobile.Text, dateBirth.Value.Date,
                        //    RadioButtonResult(rdbMale, rdbFemale), cmbNational.SelectedItem.ToString(), txtEmail.Text, txtTel.Text
                        //    , cmbState.SelectedItem.ToString(), txtCity.Text, txtAddress.Text);

                       // NewBook.customerInfo = customer;
                        //NewBook.statusFlag = 1;
                    }
                    else
                    {
                        PanelStatus(panelStatusCustomer, "Unable to Complete Action", Status.Red);
                    }




                }

                else if (!isFindCustomer)
                {
                    btnNext.Visible = true;
                    btnSubmit.Enabled = false;
                    var resultCustomer = HotelDatabase.Customer.Insert(ActID);
                    if (resultCustomer > 0)
                    {
                        CustomerID = resultCustomer;
                        //NewBook.currentCustomerID = resultCustomer;
                        PanelStatus(panelStatusCustomer, "Action Completed Successfuly", Status.Green);
                        // NewBook.statusFlag = 1;
                        //btnCustSubmit.Enabled = false;
                        //btnNext.Visible = true;
                        //isFindCutomerFlag = false;
                        CustomerSecond customer = new CustomerSecond(CustomerID, ActID, txtFname.Text, txtLname.Text, txtNCSearch.Text, txtMobile.Text, dateBirth.Value.Date,
                            RadioButtonResult(rdbMale, rdbFemale), cmbNational.SelectedItem.ToString(), txtEmail.Text, txtTel.Text
                            , cmbState.SelectedItem.ToString(), txtCity.Text, txtAddress.Text);

                        NewBook.customerInfo = customer;
                        NewBook.statusFlag = 1;
                    }
                    else
                    {
                        PanelStatus(panelStatusCustomer, "Unable to Complete Action - Customer Exist Already", Status.Red);
                    }

                }             

            }
            

        }


        private bool updateFlag = false;
        private void btnEditCustomer_Click(object sender, EventArgs e)
        {

            if (isFindActor)
            {
                panelUpdate.Visible = true;
                btnSubmit.Text = "Save";
                btnSubmit.Enabled = true;
                updateFlag = true;
                panelBasic.Enabled = true;
                panelContact.Enabled = true;
            }
            else
            {
                PanelStatus(panelStatusCustomer, "First You Need Search", Status.blue);
            }
    

        }













        //        Reset();

        //            if (txtNCSearch.Text != "National Code" && txtNCSearch.Text != "")
        //            {
        //                searchFlag = true;

        //                if (HotelDatabase.Actor.SearchActor(txtNCSearch.Text))
        //                {
        //                    isFindActor = true;

        //                    ActID = HotelDatabase.Actor.ID;
        //                    txtFname.Text = HotelDatabase.Actor.Firstname;
        //                    txtLname.Text = HotelDatabase.Actor.Lastname;
        //                    txtTel.Text = HotelDatabase.Actor.Tel;
        //                    txtMobile.Text = HotelDatabase.Actor.Mobile;
        //                    txtCity.Text = HotelDatabase.Actor.City;
        //                    txtAddress.Text = HotelDatabase.Actor.Address;
        //                    txtEmail.Text = HotelDatabase.Actor.Email;
        //                    cmbNational.SelectedItem = HotelDatabase.Actor.Nationality;
        //                    cmbState.SelectedItem = HotelDatabase.Actor.State;

        //                    if (HotelDatabase.Actor.Gender == "Male") rdbMale.Checked = true;
        //                    else rdbFemale.Checked = true;

        //                    dateBirth.Value = HotelDatabase.Actor.Birthday;

        //                    var result = HotelDatabase.Customer.SearchCustomerID(ActID);
        //                    //Person Was not in Customer Table
        //                    if (result == -1 )
        //                    {


        //                        isFindCustomer = false;

        //                        PanelStatus(panelStatusCustomer, "Person Was successfully Found", Status.Green);
        //        //ChbUpdate(true);
        //        //panelBasic.Enabled = true;
        //        //panelContact.Enabled = true;
        //        //btnSubmit.Enabled = true;
        //        // btnEdit.Enabled = true;
        //        //btnNext.Enabled = false;
        //        btnSubmit.Enabled = true;





        //                    }
        //                    //Person Is In Customer Table
        //                    else if (result > 0)
        //                    {

        //                        PanelStatus(panelStatusCustomer, "Customer Was Successfully Found", Status.Green);
        //    isFindCustomer = true;
        //                        CustomerID = HotelDatabase.Customer.ID;
        //                        // ChbUpdate(false);
        //                        //panelBasic.Enabled = false;
        //                        //panelContact.Enabled = false;
        //                        // btnSubmit.Enabled = false;
        //                        //btnNext.Enabled = true;
        //                        // btnEdit.Enabled = true;
        //                        btnSubmit.Enabled = false;
        //                        btnNext.Visible = true;

        //                        Customer customer = new Customer(CustomerID, ActID, HotelDatabase.Actor.Firstname, HotelDatabase.Actor.Lastname, HotelDatabase.Actor.NationalCode,
        //                            HotelDatabase.Actor.Mobile, HotelDatabase.Actor.Birthday, HotelDatabase.Actor.Gender, HotelDatabase.Actor.Nationality,
        //                            HotelDatabase.Actor.Email, HotelDatabase.Actor.Tel, HotelDatabase.Actor.State, HotelDatabase.Actor.City, HotelDatabase.Actor.Address);

        //    NewBook.customerInfo = customer;
        //                        NewBook.statusFlag = 1;




        //                    }
        //                    //Exception
        //                    else
        //                    {
        //                        PanelStatus(panelStatusCustomer, "Unable To Complete Action", Status.Green);
        //                    }







        //                }
        //                else
        //                {
        //                    //panelInfo.Enabled = false;
        //                    isFindActor = false;
        //                   // isFindEmployee = false;
        //                    Reset();
        //panelBasic.Enabled = true;
        //                    panelContact.Enabled = true;
        //                    //panelEmployment.Enabled = true;
        //                    PanelStatus(panelStatusCustomer, "No Person Found", Status.Red);
        //                }






        //            }
    }
 }

