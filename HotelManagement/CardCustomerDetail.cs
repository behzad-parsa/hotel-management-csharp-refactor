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
using HotelManagement.Models;
using HotelManagement.Services;

namespace HotelManagement
{
    public partial class CardCustomerDetail : UserControl
    {

        private readonly CustomerService _customerService;
        private readonly ActorService _actorService; 

        Dictionary<BunifuMetroTextbox, string> txtBoxList = new Dictionary<BunifuMetroTextbox, string>();
        BunifuImageButton btnNext;
        BunifuImageButton btnBack;
        Panel panelContainerInside;
        BunifuImageButton btnDone;

        public CardCustomerDetail()
        {
            InitializeComponent();
            _actorService = new ActorService();
            _customerService = new CustomerService();
        }

        public CardCustomerDetail(Customer customer)
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
        
        
        private enum Status
        {
            Green,
            Red,
            blue
        };
        
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


            btnNext.Visible = false;

            btnSubmit.Enabled = true;


            panelBasic.Enabled = false;
            panelContact.Enabled = false;


            panelUpdate.Visible = false;
            updateFlag = false;

        }
      
        private void TextBoxClearBorderColor()
        {

            TextBoxColor(txtFname, Status.Green);
            TextBoxColor(txtLname, Status.Green);
            TextBoxColor(txtMobile, Status.Green);
            TextBoxColor(txtCity, Status.Green);
            TextBoxColor(txtEmail, Status.Green);
            TextBoxColor(txtAddress, Status.Green);
            TextBoxColor(txtTel, Status.Green);

        }

      

        private bool searchFlag = false;
        private bool isFindActor = false;
        private bool isFindCustomer = true;
        private int CustomerID = -1;
        //private Customer customer;
        private int ActID = -1;
        private void btnNCSearch_Click(object sender, EventArgs e)
        {
            Reset();
            if (txtNCSearch.Text != "National Code" && txtNCSearch.Text != "")
            {
                searchFlag = true;

                var actor = _actorService.GetActor(txtNCSearch.Text);
                if (actor != null)
                {
                    isFindActor = true;

                    ActID = actor.ID;
                    txtFname.Text = actor.Firstname;
                    txtLname.Text = actor.Lastname;
                    txtTel.Text = actor.Tel;
                    txtMobile.Text = actor.Mobile;
                    txtCity.Text = actor.City;
                    txtAddress.Text = actor.Address;
                    txtEmail.Text = actor.Email;
                    cmbNational.SelectedItem = actor.Nationality;
                    cmbState.SelectedItem = actor.State;

                    if (actor.Gender == "Male") 
                        rdbMale.Checked = true;
                    else 
                        rdbFemale.Checked = true;

                    dateBirth.Value = actor.Birthday;

                    //var result = HotelDatabase.Customer.SearchCustomerID(ActID);
                    var customer = _customerService.GetCustomer(ActID , null);
            
                    //Person Was not in Customer Table
                    if (customer == null)//result == -1 )
                    {
                        isFindCustomer = false;
                        
                        PanelStatus(panelStatusCustomer, "Person Was successfully Found", Status.Green);
                        btnSubmit.Enabled = true;
                    }

                    //Person Is In Customer Table
                    else if (customer != null)//result > 0)
                    {
                        PanelStatus(panelStatusCustomer, "Customer Was Successfully Found", Status.Green);
                        isFindCustomer = true;
                        //CustomerID = HotelDatabase.Customer.ID;
                        CustomerID = customer.ID;
                        //this.customer = customer;

                        // ChbUpdate(false);

                        btnSubmit.Enabled = false;
                        btnNext.Visible = true;


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

                    isFindActor = false;
                   // isFindEmployee = false;
                    Reset();
                    panelBasic.Enabled = true;
                    panelContact.Enabled = true;
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
                TextBoxCheck(txtCity, "City");
                TextBoxCheck(txtEmail, "Email");
                TextBoxCheck(txtAddress, "Address");
                TextBoxCheck(txtTel, "Home Phone");

                if (txtCount == 7 && txtNCSearch.Text != "" && txtNCSearch.Text != "National Code")
                {
                    if (dateBirth.Value.Date != DateTime.Now.Date)
                    {
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

                    //var result = HotelDatabase.Actor.InsertAll(txtFname.Text, txtLname.Text, dateBirth.Value.Date,
                    // txtNCSearch.Text, cmbNational.SelectedItem.ToString(), txtEmail.Text, txtTel.Text,
                    // txtMobile.Text, RadioButtonResult(rdbMale, rdbFemale), cmbState.SelectedItem.ToString(), txtCity.Text, txtAddress.Text);
                    Actor actor = new Actor()
                    {
                        Firstname = txtFname.Text,
                        Lastname = txtLname.Text,
                        Birthday = dateBirth.Value.Date,
                        NationalCode = txtNCSearch.Text,
                        Nationality = cmbNational.SelectedItem.ToString(),
                        Email = txtEmail.Text,
                        Tel = txtTel.Text,
                        Mobile = txtMobile.Text,
                        Gender = RadioButtonResult(rdbMale, rdbFemale),
                        State = cmbState.SelectedItem.ToString(),
                        City = txtCity.Text,
                        Address = txtAddress.Text
                    };
                    var resultActor = _actorService.InsertActor(actor);

                    if (resultActor)
                    {
                        //ActID = result;
                        //var resultCustomer = HotelDatabase.Customer.Insert(result)
                        actor.ID = _actorService.LastInsertedId;
                        Customer customer = new Customer(actor);
                        //var resultCustomer = _customerService.InsertCustomer(new Customer()
                        //{
                        //    ActID = _actorService.LastInsertedId
                        //});
                        var resultCustomer = _customerService.InsertCustomer(customer);
                        
                        if (resultCustomer)
                        {
                            //CustomerID = _customerService.LastInsertedId;
                            customer.ID = _customerService.LastInsertedId;

                            PanelStatus(panelStatusCustomer , "Action Completed Successfuly", Status.Green);
                            Current.User.Activities.Add(new Activity("Submit New Customer", txtFname.Text + " " + txtLname.Text + "'s information has been submited by " + Current.User.Firstname+" " +Current.User.Lastname));


                            btnNext.Visible = true;
                            btnSubmit.Enabled = false;

                            panelBasic.Enabled = false;
                            panelContact.Enabled = false;


                            //CustomerSecond customer = new CustomerSecond(CustomerID , ActID , txtFname.Text, txtLname.Text, txtNCSearch.Text, txtMobile.Text, dateBirth.Value.Date,
                            //     RadioButtonResult(rdbMale, rdbFemale), cmbNational.SelectedItem.ToString(), txtEmail.Text, txtTel.Text
                            //     , cmbState.SelectedItem.ToString(), txtCity.Text, txtAddress.Text);

                            NewBook.customerInfo = customer;
                            NewBook.statusFlag = 1;

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
                    
                    //var reslut = HotelDatabase.Actor.UpdateAll(ActID, txtFname.Text, txtLname.Text, dateBirth.Value.Date , txtNCSearch.Text,
                    //        cmbNational.SelectedItem.ToString(), txtEmail.Text,   txtTel.Text, txtMobile.Text ,
                    //        RadioButtonResult(rdbMale, rdbFemale), cmbState.SelectedItem.ToString(), txtCity.Text, txtAddress.Text);
                    Actor actor = new Actor()
                    {
                        ID = ActID,
                        Firstname = txtFname.Text,
                        Lastname = txtLname.Text,
                        Birthday = dateBirth.Value.Date,
                        NationalCode = txtNCSearch.Text,
                        Nationality = cmbNational.SelectedItem.ToString(),
                        Email = txtEmail.Text,
                        Tel = txtTel.Text,
                        Mobile = txtMobile.Text,
                        Gender = RadioButtonResult(rdbMale, rdbFemale),
                        State = cmbState.SelectedItem.ToString(),
                        City = txtCity.Text,
                        Address = txtAddress.Text
                    };
                    var result = _actorService.UpdateActor(actor);

                    if (result)
                    {
                        updateFlag = false;
                        PanelStatus(panelStatusCustomer, "Information Changed Successfuly", Status.Green);
                        Current.User.Activities.Add(new Activity("Edit Customer Information", txtFname.Text + " " + txtLname.Text + "'s information has been changed by " + Current.User.Firstname + " " + Current.User.Lastname));

                        btnSubmit.Text = "Submit";

                        if (isFindCustomer)
                        {
                            btnSubmit.Enabled = false;
                            //CustomerSecond customer = new CustomerSecond(CustomerID, ActID, txtFname.Text, txtLname.Text, txtNCSearch.Text, txtMobile.Text, dateBirth.Value.Date,
                            //    RadioButtonResult(rdbMale, rdbFemale), cmbNational.SelectedItem.ToString(), txtEmail.Text, txtTel.Text
                            //    , cmbState.SelectedItem.ToString(), txtCity.Text, txtAddress.Text);
                            var customer = new Customer(CustomerID, actor);
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
                    //var resultCustomer = HotelDatabase.Customer.Insert(ActID);
                    var actor = new Actor()
                    {
                        ID = ActID,
                        Firstname = txtFname.Text,
                        Lastname = txtLname.Text,
                        Birthday = dateBirth.Value.Date,
                        NationalCode = txtNCSearch.Text,
                        Nationality = cmbNational.SelectedItem.ToString(),
                        Email = txtEmail.Text,
                        Tel = txtTel.Text,
                        Mobile = txtMobile.Text,
                        Gender = RadioButtonResult(rdbMale, rdbFemale),
                        State = cmbState.SelectedItem.ToString(),
                        City = txtCity.Text,
                        Address = txtAddress.Text
                    };
                    var customer = new Customer(actor);
                    var resultCustomer = _customerService.InsertCustomer(customer);
                    if (resultCustomer)
                    {
                        //CustomerID = resultCustomer;
                        customer.ID = _customerService.LastInsertedId;
      
                        PanelStatus(panelStatusCustomer, "Action Completed Successfuly", Status.Green);

                        //CustomerSecond customer = new CustomerSecond(CustomerID, ActID, txtFname.Text, txtLname.Text, txtNCSearch.Text, txtMobile.Text, dateBirth.Value.Date,
                        //    RadioButtonResult(rdbMale, rdbFemale), cmbNational.SelectedItem.ToString(), txtEmail.Text, txtTel.Text
                        //    , cmbState.SelectedItem.ToString(), txtCity.Text, txtAddress.Text);
 
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

    }
 }

