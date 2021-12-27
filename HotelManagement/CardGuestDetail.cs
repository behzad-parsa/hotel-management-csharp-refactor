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
    public partial class CardGuestDetail : UserControl
    {
        Dictionary<BunifuMetroTextbox, string> txtBoxList = new Dictionary<BunifuMetroTextbox, string>();
        BunifuImageButton btnBack;
        BunifuImageButton btnNext;
        Panel panelContainerInside;
        private enum Status
        {
            Green,
            Red,
            blue
        };
        public CardGuestDetail()
        {
            InitializeComponent();
        }

        private void CardGuestDetail_Load(object sender, EventArgs e)
        {
            NewBook.statusFlag = 2;
            NewBook.backFalg = 1;
            btnBack = (this.Parent.Parent as NewBook).Controls["btnBack"] as BunifuImageButton;
            btnNext = (this.Parent.Parent as NewBook).Controls["btnNext"] as BunifuImageButton;

            btnBack.Visible = true;
            btnNext.Visible = true;
            panelContainerInside = (this.Parent.Parent as NewBook).Controls["panelContainerInside"] as Panel;


            lblBitrh.Text = NewBook.customerInfo.Birthday.Date.ToString("MM / dd / yyyy");
            lblGender.Text = NewBook.customerInfo.Gender;
            lblName.Text = NewBook.customerInfo.Firstname + " " + NewBook.customerInfo.Lastname;
            lblNC.Text = NewBook.customerInfo.NationalCode;
            lblStateCity.Text = NewBook.customerInfo.State + "," + NewBook.customerInfo.City;

            //DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);
            //var data = HotelDatabase.Guest.SearchGuest(NewBook.customerInfo.ID, date);






            dataTable.Columns.Add("NC");
            dataTable.Columns.Add("Name");
            dataTable.Columns.Add("Date");

            LoadGuestData();


            //btnBack.Click += BtnBack_Click;

        }

        //private void BtnBack_Click(object sender, EventArgs e)
        //{
        //    panelContainerInside.Controls.Clear();


        //    CardCustomerDetail cardCustomer = new CardCustomerDetail(NewBook.customerInfo);

        //    panelContainerInside.Controls.Add(cardCustomer) ;
        //}

        private void LoadGuestData()
        {
            //if (NewBook.customerInfo.LstGuest.Count !=0)
            //{
            //    //foreach (var item in NewBook.customerInfo.LstGuest)
            //    //{
            //    //    DataRow dr = dataTable.NewRow();
            //    //    dr["NC"] = item.NationalCode;
            //    //    dr["Name"] = item.Firstname + " " + item.Lastname;
            //    //    dr["Date"] = DateTime.Now.Date;

            //    //    dataTable.Rows.Add(dr);


            //    //}
                


            //}
            //else
            //{
            //    //Empty List
            //}
            //DateTime date = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day);

            var query = "Select ActID ,  NationalCode AS NC ,  Firstname +' '+Lastname As Name  , DateModified AS Date , Gender , Birthday , Mobile  From Actor a , Guest g Where a.id = g.ActID And g.CustomerID = " + NewBook.customerInfo.ID + " And g.DateModified = '" +DateTime.Now.Date + "'";

            var data = HotelDatabase.Database.Query(query);

            if (data != null)
            {
                dataTable = data;
                dgvGuestList.DataSource = data;
                dgvGuestList.Columns["ActID"].Visible = false;
                dgvGuestList.Columns["Gender"].Visible = false;
                dgvGuestList.Columns["Birthday"].Visible = false;
                dgvGuestList.Columns["Mobile"].Visible = false;
                dgvGuestList.ClearSelection();
                NewBook.customerInfo.LstGuest.Clear(); //*******************************
                foreach (DataRow item in data.Rows)
                {
                    string[] name = item["Name"].ToString().Split(' ');
                    Guest guest = new Guest(Convert.ToInt32(item["ActID"]) , Convert.ToDateTime( item["Date"] ), name[0] , name[1] , item["NC"].ToString()  , item["Gender"].ToString(), Convert.ToDateTime( item["Birthday"] ), item["Mobile"].ToString());
                    NewBook.customerInfo.LstGuest.Add(guest);

                }



            }
            else
            {
                //Empty List
            }
 

        }
        private void AddGuestToDGV(Guest guest)
        {
            DataRow dr = dataTable.NewRow();
            dr["NC"] = guest.NationalCode;
            dr["Name"] = guest.Firstname + " " + guest.Lastname;
            dr["Date"] = DateTime.Now.Date.ToString("MM / dd / yyyy");

            dataTable.Rows.Add(dr);
            dgvGuestList.DataSource = dataTable;
            dgvGuestList.ClearSelection();
        }

        private void TextBoxEnter(object sender, EventArgs e)
        {
            var txtBox = sender as BunifuMetroTextbox;
            //panelGuestStatus.Visible = false;
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



        //private void PanelStatus(string text, Status status)
        //{
        //    panelGuestStatus.Visible = true;
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

        private int txtCount = 0;
        private bool ValidationFlag = false;
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
        private bool TextBoxCheck(BunifuMetroTextbox txtBox, string txt)
        {
            if (txtBox.Text == txt || txtBox.Text == "")
            {
                TextBoxColor(txtBox, Status.Red);
                return false;
            }
            //else if (txt == "National Code")
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

        //private void TextBoxClearText()
        //{
        //    txtGuestFname.Text = "Firstname";
        //    txtGuestFname.ForeColor = Color.Gray;

        //    txtGuestLname.Text = "Lastname";
        //    txtGuestLname.ForeColor = Color.Gray;

        //    txtGuestMobile.Text = "Mobile Phone";
        //    txtGuestMobile.ForeColor = Color.Gray;
        //    //txtCustNationalCode.Text = "National Code";
        //    //txtCustCity.Text = "City";
        //    //txtGuestEmail.Text = "Email";
        //    //txtCustAddress.Text = "Address";
        //    //txtGuestTel.Text = "Home Phone";
        //    dateGuestBirth.Value = DateTime.Now.Date;
        //}
        private void TextBoxClearBorderColor()
        {

            TextBoxColor(txtFname, Status.Green);
            TextBoxColor(txtLname, Status.Green);
            TextBoxColor(txtMobile, Status.Green);
            //TextBoxColor(txtGuestNationalCode , Status.blue);
            //TextBoxColor(txCity, Status.Green);
            //TextBoxColor(txtCustEmail, Status.Green);
            //TextBoxColor(txtCustAddress, Status.Green);
            //TextBoxColor(txtCustTel, Status.Green);

        }

        //private bool isFindGuestFlag = false;  

        private void btnGuestSearch_Click(object sender, EventArgs e)
        {
            //txtGuestNationalCode.Focus();

            //btnGuestSubmit.Enabled = true;

            //panelGuestStatusWaiting.Visible = true;
            //TextBoxClearBorderColor();

            //if (txtGuestNationalCode.Text != "National Code" && txtGuestNationalCode.Text != "")
            //{
                
            //    if (HotelDatabase.Actor.SearchActor(txtGuestNationalCode.Text))
            //    {
            //        if (HotelDatabase.Actor.ID != NewBook.currentCustomerID)
            //        {
            //            panelGuestContainer.Enabled = false;
            //            isFindGuestFlag = true;
                
            //            NewBook.statusFlag = 2;


            //            PanelStatus("Guest Was successfully Found", Status.Green);


            //            txtGuestFname.Text = HotelDatabase.Actor.Firstname;
            //            txtGuestLname.Text = HotelDatabase.Actor.Lastname;

            //            txtGuestMobile.Text = HotelDatabase.Actor.Mobile;
            //            txtGuestNationalCode.Text = HotelDatabase.Actor.NationalCode;
            //            dateGuestBirth.Value = HotelDatabase.Actor.Birthday.Date; //Min Value As Null
            //            if (HotelDatabase.Actor.Gender == "Male") rdbGuestMale.Checked = true;
            //            else rdbGuestFemale.Checked = true;





            //           // panelGuestStatusWaiting.Visible = false;
            //        }
            //        else
            //        {

            //            PanelStatus("Customer And Perseon Is Same", Status.Red);

            //        }
                   
            //    }
            //    else
            //    {
            //        PanelStatus("No Person found", Status.Red);
            //        TextBoxClearText();
            //        btnGuestSubmit.Enabled = true;
            //        panelGuestContainer.Enabled = true;

            //        isFindGuestFlag = false;
            //        //btnNext.Visible = false;

            //    }
            //}
            //else
            //{
            //    PanelStatus("Enter National Code", Status.Red);
            //    TextBoxColor(txtGuestNationalCode, Status.Red);
            //}

            //// pgbCust.Visible = false;
            ////lblCustWaiting.Visible = false;


            //panelGuestStatusWaiting.Visible = false;

        }


        private void btnGuestSubmit_Click(object sender, EventArgs e)
        {
            //panelGuestStatusWaiting.Visible = true;


            //TextBoxCheck(txtGuestFname, "Firstname");
            //TextBoxCheck(txtGuestLname, "Lastname");
            //TextBoxCheck(txtGuestMobile, "Mobile Phone");
            //TextBoxCheck(txtGuestNationalCode, "National Code");

            //if (txtCount == 4)
            //{
            //    if (dateGuestBirth.Value.Date != DateTime.Now.Date)
            //    {

            //        panelGuestStatus.Visible = false;
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
            //    if (!isFindGuestFlag)
            //    {
            //        var result = HotelDatabase.Actor.InsertGuest(txtGuestFname.Text, txtGuestLname.Text, dateGuestBirth.Value.Date, txtGuestNationalCode.Text, txtGuestMobile.Text, RadioButtonResult(rdbGuestMale, rdbGuestFemale));
            //        if (result>0)
            //        {
            //            if (HotelDatabase.Guest.Insert(result , NewBook.currentCustomerID) > 0)
            //            {
            //                btnGuestSubmit.Enabled = false;
            //                panelGuestContainer.Enabled = false;
            //                NewBook.statusFlag = 2;
            //                PanelStatus("Action Completed Successfuly", Status.Green);

            //            }
            //            else
            //            {
            //                PanelStatus("Unable to Complete Action", Status.Red);
            //            }


            //        }
            //        else
            //        {
            //            PanelStatus("Unable to Complete Action (Maybe National Code Exist Already)", Status.Red);
            //        }


            //    }


            //    else if (isFindGuestFlag)
            //    {

            //        if (HotelDatabase.Guest.Insert(HotelDatabase.Actor.ID, NewBook.currentCustomerID) >0)
            //        {
            //            btnGuestSubmit.Enabled = false;

            //            isFindGuestFlag = false;
            //            PanelStatus("Action Completed Successfuly", Status.Green);
            //            NewBook.statusFlag = 2;
            //        }
            //        else
            //        {
            //            PanelStatus("Unable to Complete Action", Status.Red);
            //        }






            //    }
            //}


        



            //panelGuestStatusWaiting.Visible = false;
        }

        //private void txtGuestNationalCode_OnValueChanged(object sender, EventArgs e)
        //{
            
        //}

        private bool searchFlag = false;
        private int  ActID = -10;
        private bool isFindGuest = false;
        //private bool isFindActor = false;
        private void btnNCSearch_Click(object sender, EventArgs e)
        {
            Reset();

            if (txtNCSearch.Text != "National Code" && txtNCSearch.Text != "")
            {
                searchFlag = true;

                if (HotelDatabase.Actor.SearchActor(txtNCSearch.Text))
                {
                    



                    if (txtNCSearch.Text != NewBook.customerInfo.NationalCode)
                    {
                        //isFindActor = true;

                        var search = NewBook.customerInfo.LstGuest.Find(x => x.NationalCode == txtNCSearch.Text);
                        if (search == null)
                        {

                            isFindGuest = true;

                            ActID = HotelDatabase.Actor.ID;
                            txtFname.Text = HotelDatabase.Actor.Firstname;
                            txtLname.Text = HotelDatabase.Actor.Lastname;
                            txtMobile.Text = HotelDatabase.Actor.Mobile;
                            if (HotelDatabase.Actor.Gender == "Male") rdbMale.Checked = true;
                            else rdbFemale.Checked = true;
                            dateBirth.Value = HotelDatabase.Actor.Birthday;


                            //NewBook.statusFlag = 2;
                            PanelStatus(panelStatusGuest, "Guest Was successfully Found", Status.Green);
                            

                            //if (HotelDatabase.Guest.SearchGuest(NewBook.customerInfo.ID , DateTime.Now.Date))
                            //{
                            //    isFindGuest = true;


                            //}
                            //else
                            //{
                            //    isFindGuest = false;

                            //}


                        }
                        else
                        {
                            isFindGuest = false;
                            panelBasic.Enabled = false;
                            searchFlag = false;
                            PanelStatus(panelStatusGuest, "The Guest Has Already Been Added", Status.Red);

                        }
                        //panelGuestContainer.Enabled = false;
                        //isFindGuestFlag = true;



                        //txtGuestFname.Text = HotelDatabase.Actor.Firstname;
                        //txtGuestLname.Text = HotelDatabase.Actor.Lastname;

                        //txtGuestMobile.Text = HotelDatabase.Actor.Mobile;
                        //txtGuestNationalCode.Text = HotelDatabase.Actor.NationalCode;
                        //dateGuestBirth.Value = HotelDatabase.Actor.Birthday.Date; //Min Value As Null
                        //if (HotelDatabase.Actor.Gender == "Male") rdbGuestMale.Checked = true;
                        //else rdbGuestFemale.Checked = true;


       

                        //NewBook.customerInfo.LstGuest.Add()
                        // panelGuestStatusWaiting.Visible = false;
                    }
                    else
                    {
                        isFindGuest = false;
                        //isFindActor = false;
                        panelBasic.Enabled = false;
                        searchFlag = false;
                        PanelStatus(panelStatusGuest , "Customer And Guest Is Same", Status.Red);

                    }

                    //var result = HotelDatabase.Customer.SearchCustomerID(ActID);
                    ////Person Was not in Customer Table
                    //if (result == -1)
                    //{


                    //    isFindCustomer = false;

                    //    PanelStatus(panelStatusCustomer, "Person Was successfully Found", Status.Green);
                    //    //ChbUpdate(true);
                    //    //panelBasic.Enabled = true;
                    //    //panelContact.Enabled = true;
                    //    //btnSubmit.Enabled = true;
                    //    // btnEdit.Enabled = true;
                    //    //btnNext.Enabled = false;
                    //    btnSubmit.Enabled = true;





                    //}
                    ////Person Is In Customer Table
                    //else if (result > 0)
                    //{

                    //    PanelStatus(panelStatusCustomer, "Customer Was Successfully Found", Status.Green);
                    //    isFindCustomer = true;
                    //    CustomerID = HotelDatabase.Customer.ID;
                    //    // ChbUpdate(false);
                    //    //panelBasic.Enabled = false;
                    //    //panelContact.Enabled = false;
                    //    // btnSubmit.Enabled = false;
                    //    //btnNext.Enabled = true;
                    //    // btnEdit.Enabled = true;
                    //    btnSubmit.Enabled = false;
                    //    btnNext.Visible = true;

                    //    Customer customer = new Customer(CustomerID, ActID, HotelDatabase.Actor.Firstname, HotelDatabase.Actor.Lastname, HotelDatabase.Actor.NationalCode,
                    //        HotelDatabase.Actor.Mobile, HotelDatabase.Actor.Birthday, HotelDatabase.Actor.Gender, HotelDatabase.Actor.Nationality,
                    //        HotelDatabase.Actor.Email, HotelDatabase.Actor.Tel, HotelDatabase.Actor.State, HotelDatabase.Actor.City, HotelDatabase.Actor.Address);

                    //    NewBook.customerInfo = customer;
                    //    NewBook.statusFlag = 1;




                    //}
                    ////Exception
                    //else
                    //{
                    //    PanelStatus(panelStatusCustomer, "Unable To Complete Action", Status.Green);
                    //}







                }
                else
                {
                    //panelInfo.Enabled = false;
                    isFindGuest = false;
                    // isFindEmployee = false;
                    Reset();
                    //panelBasic.Enabled = true;
                    //panelContact.Enabled = true;
                    panelBasic.Enabled = true;
                    //panelEmployment.Enabled = true;
                    PanelStatus(panelStatusGuest, "No Person Found", Status.Red);
                }






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
            //txtCustNationalCode.Text = "National Code";
            //txtCustCity.Text = "City";
            //txtGuestEmail.Text = "Email";
            //txtCustAddress.Text = "Address";
            //txtGuestTel.Text = "Home Phone";
            dateBirth.Value = DateTime.Now.Date;
            TextBoxClearBorderColor();

            panelBasic.Enabled = false;

            panelStatusGuest.Visible = false;

            isFindGuest = false;

            ActID = -1;

            updateFlag = false;

            btnAdd.Text = "Add";

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

        DataTable dataTable = new DataTable();

        private void btnAdd_Click(object sender, EventArgs e)
        {


            //if (searchFlag &&  )
            //{

            //}
            //panelBasic.Focus();


            //Guest guest = new Guest(ActID, DateTime.Now.Date, txtFname.Text, txtLname.Text, txtNCSearch.Text, RadioButtonResult(rdbMale, rdbFemale), dateBirth.Value.Date, txtMobile.Text);


            if (isFindGuest)
            {
                Guest guest = new Guest(ActID, DateTime.Now.Date, txtFname.Text, txtLname.Text, txtNCSearch.Text, RadioButtonResult(rdbMale, rdbFemale), dateBirth.Value.Date, txtMobile.Text);
                //On Add
                //var g = NewBook.customerInfo.LstGuest.Find(x => x.NationalCode == guest.NationalCode);
                if (!updateFlag)
                {
                    var res = HotelDatabase.Guest.Insert(ActID, NewBook.customerInfo.ID);
                    if (res > 0)
                    {
                        //Guest guest = new Guest(ActID, DateTime.Now.Date, txtFname.Text, txtLname.Text, txtNCSearch.Text, RadioButtonResult(rdbMale, rdbFemale), dateBirth.Value.Date, txtMobile.Text);
                        NewBook.customerInfo.LstGuest.Add(guest);
                        AddGuestToDGV(guest);
                        panelBasic.Enabled = false;
                        isFindGuest = false;
                        PanelStatus(panelStatusGuest, "Action Completed Successfuly", Status.Green);
                        searchFlag = false;

                    }
                    else
                    {
                        PanelStatus(panelStatusGuest, "Unable to Complete Action ", Status.Red);

                    }


                }
                //On UpdateMode
                else
                {
                    


                    
                    var res = HotelDatabase.Actor.UpdateGuest(ActID , txtFname.Text , txtLname.Text , dateBirth.Value.Date , txtNCSearch.Text , txtMobile.Text , RadioButtonResult(rdbMale , rdbFemale) );
                    //Guest guest = new Guest(ActID, DateTime.Now.Date, txtFname.Text, txtLname.Text, txtNCSearch.Text, RadioButtonResult(rdbMale, rdbFemale), dateBirth.Value.Date, txtMobile.Text);

                    if (res)
                    {
                        updateFlag = false;
                        panelUpdate.Visible = false;
                        panelBasic.Enabled = false;
                        btnAdd.Text = "Add";

                        PanelStatus(panelStatusGuest, "Information Changed Successfully", Status.Green);

                        var search = NewBook.customerInfo.LstGuest.Find(x => x.ID == ActID);
                        if (search != null)
                        {
                            NewBook.customerInfo.LstGuest.Remove(search);
                            NewBook.customerInfo.LstGuest.Add(guest);
                            isFindGuest = false;
                            selectedGuest = null;
                            LoadGuestData();

                        }


                    }
                    else
                    {

                        PanelStatus(panelStatusGuest, "Unable to Complete Action ", Status.Red);


                    }




                }




            }
            else if (searchFlag) 
            {
        

                TextBoxCheck(txtFname, "Firstname");
                TextBoxCheck(txtLname, "Lastname");
                TextBoxCheck(txtMobile, "Mobile Phone");
                //TextBoxCheck(txtNationalCode, "National Code");

                if (txtCount == 3 & txtNCSearch.Text != "" && txtNCSearch.Text != "National Code")
                {
                    if (dateBirth.Value.Date != DateTime.Now.Date)
                    {

                        //panelGuestStatus.Visible = false;
                        ValidationFlag = true;


                    }
                    else
                    {
                        PanelStatus(panelStatusGuest, "Choose Birthday", Status.Red);

                    }


                }
                else
                {

                    PanelStatus(panelStatusGuest, "Please Fill The Blank", Status.Red);
                }
                txtCount = 0;


                if (ValidationFlag)
                {
                    ValidationFlag = false;

                    //var result = HotelDatabase.Actor.InsertGuest( txtGuestMobile.Text, RadioButtonResult(rdbGuestMale, rdbGuestFemale));
                    var result = HotelDatabase.Actor.InsertAll(txtFname.Text, txtLname.Text, dateBirth.Value.Date, txtNCSearch.Text, "Not Available", "Not Available", "Not Available", txtMobile.Text, RadioButtonResult(rdbMale, rdbFemale), "Not Available", "Not Available", "Not Available");

                    if (result > 0)
                    {
                        if (HotelDatabase.Guest.Insert(result, NewBook.customerInfo.ID) > 0)
                        {
                            // btnGuestSubmit.Enabled = false;
                            //panelGuestContainer.Enabled = false;
                            //NewBook.statusFlag = 2;
                            PanelStatus(panelStatusGuest, "Action Completed Successfuly", Status.Green);
                            Guest guest = new Guest(ActID , DateTime.Now.Date, txtFname.Text, txtLname.Text, txtNCSearch.Text, RadioButtonResult(rdbMale, rdbFemale), dateBirth.Value.Date, txtMobile.Text);
                            NewBook.customerInfo.LstGuest.Add(guest);
                            AddGuestToDGV(guest);

                            panelBasic.Enabled = false;
                            searchFlag = false;


                        }
                        else
                        {
                            PanelStatus(panelStatusGuest, "Unable to Complete Action (Maybe National Code Exist Already)", Status.Red);
                        }


                        //else if (isFindGuestFlag)
                        //{

                        //    if (HotelDatabase.Guest.Insert(HotelDatabase.Actor.ID, NewBook.currentCustomerID) > 0)
                        //    {
                        //        btnGuestSubmit.Enabled = false;

                        //        isFindGuestFlag = false;
                        //        PanelStatus("Action Completed Successfuly", Status.Green);

                        //    }
                        //    else
                        //    {
                        //        PanelStatus("Unable to Complete Action", Status.Red);
                        //    }






                        //}
                    }






                }
            }
            else
            {
                PanelStatus(panelStatusGuest, "Use Search Bar To Find Person", Status.blue);
            }
        }


        Guest selectedGuest;
        private void dgvGuestList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvGuestList.CurrentRow != null)
            {

                string nc = dgvGuestList["NC", dgvGuestList.CurrentRow.Index].Value.ToString();
                selectedGuest = NewBook.customerInfo.LstGuest.Find(x => x.NationalCode == nc);
                ActID = selectedGuest.ID;



            }
        }

        private void btnDeleteGuest_Click(object sender, EventArgs e)
        {
            if (selectedGuest == null)
            {
                MessageBox.Show("Please Select Row");
            }
            else
            {

                var res = MessageBox.Show("Are You Sure You Want To Delete '" + selectedGuest.Firstname + ' ' + selectedGuest.Lastname + "' ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    if (HotelDatabase.Guest.Delete(selectedGuest.ID, NewBook.customerInfo.ID, selectedGuest.DateModified))
                    {
                        NewBook.customerInfo.LstGuest.Remove(selectedGuest);
                        LoadGuestData();
                        dgvGuestList.ClearSelection();
                    }
                    else
                    {
                        MessageBox.Show("Unable To Compelete Action ", "Delete Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    }
                }
                selectedGuest = null;

            }


        }
        private bool updateFlag = false;
        private void btnEditCustomer_Click(object sender, EventArgs e)
        {
            if (isFindGuest)
            {

                panelUpdate.Visible = true;
                btnAdd.Text = "Save";
                updateFlag = true;
                panelBasic.Enabled = true;



            }
        }

        private void dgvGuestList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btnEditList_Click(object sender, EventArgs e)
        {
            if (selectedGuest == null)
            {
                MessageBox.Show("Please Select Row");
            }
            else
            {

                isFindGuest = true;
                panelUpdate.Visible = true;
                btnAdd.Text = "Save";
                updateFlag = true;
                panelBasic.Enabled = true;

                txtNCSearch.Text = selectedGuest.NationalCode;
                txtFname.Text = selectedGuest.Firstname;
                txtLname.Text = selectedGuest.Lastname;
                dateBirth.Value = selectedGuest.Birthday;
                if (selectedGuest.Gender == "Male") rdbMale.Checked = true;
                else rdbFemale.Checked = true;
                txtMobile.Text = selectedGuest.Mobile;

                txtBoxList.Clear();
                


                //selectedGuest = null;

            }
        }
    }
}
