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
    public partial class NewRoom : UserControl
    {
        Dictionary<int, string> lstFacilities = new Dictionary<int, string>();
        Dictionary<BunifuMetroTextbox, string> lstTxtBoxList = new Dictionary<BunifuMetroTextbox, string>();
        List<CheckBox> lstCheckBox;
        Dictionary<int , string> roomNumber;
        Dictionary<int, string> roomType;
        Dictionary<int, string> facility;
        public NewRoom()
        {
            InitializeComponent();
        }

        private void LoadData()
        {
            //Bad Naming - Need Modify
            var h = HotelDatabase.Database.Query("Select Distinct r.id as ID, rn.Title as Number , Capacity , Floor , Price  , rt.Title as Type From Room as r , RoomNumber as rn , RoomTypeRel rtl , RoomType rt  " +
            "Where r.isEmpty = 1 And rn.id = r.RoomNumberID And r.Id = rtl.RoomID And rtl.RoomTypeID = rt.id And r.BranchID = " + Current.User.BranchID + " ORder BY r.id ASC");

            h.Columns.Add("Facil");

            //Bad Naming
            var t = HotelDatabase.Database.Query("Select DISTINCT r.id , f.Title From Room as r , facilities f , RoomFacilities rf Where r.id = rf.RoomID ANd  f.id = rf.FacilitiesID ORder BY r.id ASC");

            string d = null;
            int i_val;
            int j_val;
            for (int i = 0, j = i + 1; i < t.Rows.Count; i++, j++)
            {


                i_val = Convert.ToInt32(t.Rows[i]["id"]);
                if (j < t.Rows.Count)
                {
                    j_val = Convert.ToInt32(t.Rows[j]["id"]);
                }
                else
                {
                    j_val = -1;
                }
                //j_val = Convert.ToInt32(t.Rows[j]["id"]);

                d += "- " + t.Rows[i]["Title"].ToString() + "\n";

                if (i_val != j_val)
                {
                    //dix.Add(i_val, d);
                    //d = null;
                    //r["facil"] = d;

                    //DataRow dr = h.Select("ID =" + i_val.ToString()).FirstOrDefault(); 
                    //if (dr != null)
                    //{
                    //    dr["facil"] = d; 
                    //    h.Rows.Add(D)
                    //}

                    foreach (DataRow dr in h.Rows) // search whole table
                    {
                        if (Convert.ToInt32(dr["ID"]) == i_val) // if id==2
                        {
                            dr["facil"] = d; //change the name
                            break;
                            //break; break or not depending on you
                        }
                    }
                    d = null;

                    //if (h.DefaultView.RowFilter = "ID LIKE '%" + i_val + "%'")
                    //{

                    //}
                }

                //_id = Convert.ToInt32(t.Rows[i]["id"]);

                //if (_id == Convert.ToInt32(t.Rows[i]["id"]))
                //{
                //    d += t.Rows[i]["Title"].ToString() + "\n";
                //}


            }

            dgvRoom.DataSource = h;
            dgvRoom.Columns["id"].Visible = false;
            dgvRoom.Columns["Facil"].Width = 145;
        }

        List<int> lstChoosedFacilitiesID = new List<int>();
        private void NewRoom_Load(object sender, EventArgs e)
        {

            //----Room List ----
            LoadData();
            roomNumber = HotelDatabase.Room.GetRoomNumbers();
            roomType = HotelDatabase.Room.GetRoomTypes();
            facility = HotelDatabase.Room.GetFacilities();
            foreach (var item in roomNumber)
            {
                cmbRoomNumber.Items.Add(item.Value  );

            }
            foreach (var item in roomType)
            {
                cmbRoomType.Items.Add(item.Value);
            }

            lstFacilities = HotelDatabase.Room.GetFacilities();
             lstCheckBox = new List<CheckBox>();
            
            for (int i = 1; i < lstFacilities.Count + 1; i++)
            {
                CheckBox chbFacility = new CheckBox();
                chbFacility.CheckedChanged += new EventHandler(CheckBoxSelected);
                chbFacility.AutoSize = false;
                chbFacility.Width = 268;
                chbFacility.Text = lstFacilities[i];
                if (i != 1) chbFacility.Location = new Point(chbFacility.Location.X, lstCheckBox[lstCheckBox.Count - 1].Location.Y + 40);

                lstCheckBox.Add(chbFacility);
                if (i < 12) panelLeftFacility.Controls.Add(chbFacility);
                else
                {
                    if (i == 12) chbFacility.Location = new Point(chbFacility.Location.X, lstCheckBox[0].Location.Y);
                    panelRightFacility.Controls.Add(chbFacility);
                }
            }
        }


        private void CheckBoxSelected(object sender , EventArgs e)
        {
            var checkBox = sender as CheckBox;
            var id = lstFacilities.FirstOrDefault(x => x.Value == checkBox.Text).Key;
            if (checkBox.Checked)
            {           
                lstChoosedFacilitiesID.Add(id);
            }
            else
            {
                lstChoosedFacilitiesID.Remove(id);
            }
        }

        private void TextBoxEnter(object sender, EventArgs e)
        {
            var txtBox = sender as BunifuMetroTextbox;
            txtBox.BorderColorIdle = Color.FromArgb(231, 228, 228);
            txtBox.ForeColor = Color.Black;
            if (!lstTxtBoxList.ContainsKey(txtBox))
            {
                lstTxtBoxList.Add(txtBox, txtBox.Text);
            }
            lstTxtBoxList.TryGetValue(txtBox, out string defualtText);
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
                lstTxtBoxList.TryGetValue(txtBox, out string defualtText);
                txtBox.Text = defualtText;
                txtBox.ForeColor = Color.DarkGray;
            }

        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            //------------------Branch ID Need Replace Later-----------------------------------
            //
            //cmbRoomNumber.SelectedIndex + 1
            if (insertFlag)
            {
                //btnSubmit.Text = "Submit"
                TextBoxCheck(txtPrice, "Price");
                //TextBoxCheck(txtDescription, "Description");

                if (txtCount == 1)
                {
                    ValidationFlag = true;
                }
                else
                {
                    PanelStatus(panelStatusCreate, "Please Fill The Blank", Status.Red);
                }

                txtCount = 0;
                int count = 0;

                if (ValidationFlag)
                {
                    ValidationFlag = false;
                    var roomNumberID = roomNumber.FirstOrDefault(x => x.Value == cmbRoomNumber.SelectedItem.ToString()).Key;
                    string descriptionText;
                    if (txtDescription.Text == "Description")
                    {
                        descriptionText = null;
                    }
                    else
                    {
                        descriptionText = txtDescription.Text;
                    }
                    var res = HotelDatabase.Room.Insert(Current.User.BranchID, roomNumberID, true, Convert.ToInt32(numericFloor.Value), Convert.ToInt32(numericCapacity.Value), Convert.ToInt32(txtPrice.Text), descriptionText);
                    if (res > 0)
                    {
                        //Insert Facilities
                        for (int i = 0; i < lstChoosedFacilitiesID.Count; i++)
                        {
                            if (HotelDatabase.Room.InsertFacilities(res, lstChoosedFacilitiesID[i]))
                            {
                                count++;
                            }
                            else
                            {
                                PanelStatus(panelStatusCreate, "Unable To Complete Action -- Facilities", Status.Red);
                            }
                        }

                        var roomTypeID = roomType.FirstOrDefault(x => x.Value == cmbRoomType.SelectedItem.ToString()).Key;
                        //InsertType
                        if (HotelDatabase.Room.InsertRoomType(res, roomTypeID))
                        {
                            count++;
                        }
                        else
                        {
                            PanelStatus(panelStatusCreate, "Unable To Complete Action -- Type", Status.Red);
                        }

                        if (count == lstChoosedFacilitiesID.Count + 1)
                        {
                            PanelStatus(panelStatusCreate, "Action Completed Successfully", Status.Green);
                        }
                    }
                    else
                    {
                        PanelStatus(panelStatusCreate, "Unable To Complete Action", Status.Red);
                    }
                }
                Reset();
            }
            else
            {
                TextBoxCheck(txtPrice, "Price");
                if (txtCount == 1)
                {
                    ValidationFlag = true;
                }
                else
                {
                    PanelStatus(panelStatusCreate, "Please Fill The Blank", Status.Red);
                }

                txtCount = 0;
                int count = 0;

                if (ValidationFlag)
                {
                    ValidationFlag = false;

                    var roomNumberID = roomNumber.FirstOrDefault(x => x.Value == cmbRoomNumber.SelectedItem.ToString()).Key;
                    string descriptionText;
                    if (txtDescription.Text == "Description")
                    {
                        descriptionText = null;
                    }
                    else
                    {
                        descriptionText = txtDescription.Text;
                    }
                    var res = HotelDatabase.Room.Update(RoomID, Current.User.BranchID, roomNumberID, true, Convert.ToInt32(numericFloor.Value), Convert.ToInt32(numericCapacity.Value), Convert.ToInt32(txtPrice.Text), descriptionText);
                    if (res)
                    {
                        if (HotelDatabase.Room.DeleteFacilType(RoomID))
                        {
                            //Insert Facilities
                            for (int i = 0; i < lstChoosedFacilitiesID.Count; i++)
                            {
                                if (HotelDatabase.Room.InsertFacilities(RoomID, lstChoosedFacilitiesID[i]))
                                {
                                    count++;
                                }
                                else
                                {
                                    PanelStatus(panelStatusCreate, "Unable To Complete Action -- Facilities", Status.Red);
                                }
                            }

                            var roomTypeID = roomType.FirstOrDefault(x => x.Value == cmbRoomType.SelectedItem.ToString()).Key;
                            //InsertType
                            if (HotelDatabase.Room.InsertRoomType(RoomID, roomTypeID))
                            {
                                count++;
                            }
                            else
                            {
                                PanelStatus(panelStatusCreate, "Unable To Complete Action -- Type", Status.Red);
                            }

                            if (count == lstChoosedFacilitiesID.Count + 1)
                            {
                                PanelStatus(panelStatusCreate, "Action Completed Successfully", Status.Green);
                                Current.User.Activities.Add(new Activity("Create New Room", "New Room has been created by " + Current.User.Firstname + " " + Current.User.Lastname));

                            }
                        }
                        else
                        {
                            PanelStatus(panelStatusCreate, "Unable To Complete Action -- Facilities", Status.Red);

                        }
                    }
                    else
                    {
                        PanelStatus(panelStatusCreate, "Unable To Complete Action", Status.Red);
                    }

                }

                btnSubmit.Text = "Submit";
                insertFlag = true;
                Reset();
            }
            LoadData();
        }

        private enum Status
        {
            Green,
            Red,
            blue
        };
        private static int txtCount = 0;
        private bool ValidationFlag = false;

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
            else if (txt == "National Code")
            {
                TextBoxColor(txtBox, Status.blue);
                txtCount++;
                return true;
            }
            else
            {
                TextBoxColor(txtBox, Status.Green);
                txtCount++;
                return true;
            }
        }

        private void TextBoxClearText()
        {
            txtPrice.Text = "Price";
            txtPrice.ForeColor = Color.Gray;

            txtDescription.Text = "Description";
            txtDescription.ForeColor = Color.Gray;

            numericCapacity.Value = 1;
            numericFloor.Value = 1;
        }

        private void TextBoxClearBorderColor()
        {
            TextBoxColor(txtDescription, Status.Green);
            TextBoxColor(txtPrice, Status.Green);
        }

        bool updateFlag;
        bool insertFlag;
        private void dgvRoom_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            //----Setting-----
            Reset();
            btnSubmit.Text = "Save";
            updateFlag = true;
            insertFlag = false;
            //lstChoosedFacilitiesID.Clear();

            //---Load Room Data--------------------------------------------------------
            RoomID = Convert.ToInt32(dgvRoom["ID", dgvRoom.CurrentRow.Index].Value);
            if (HotelDatabase.Room.SearchRoomWithID(RoomID))
            {
                txtPrice.Text = HotelDatabase.Room.Price.ToString();
                txtDescription.Text = HotelDatabase.Room.Description;
                numericFloor.Value = HotelDatabase.Room.Floor;
                numericCapacity.Value = HotelDatabase.Room.Capacity;
                var var = roomType.TryGetValue(HotelDatabase.Room.TypeID, out string type);
                cmbRoomType.SelectedItem = type;

                roomNumber.TryGetValue(HotelDatabase.Room.RoomNumberID, out string number);
                cmbRoomNumber.SelectedItem = number;
                //HotelDatabase.Room.RoomFacility(RoomID);
                if (HotelDatabase.Room.facility != null)
                {                   
                    foreach (var item in facility)
                    {
                        var data = HotelDatabase.Room.facility.Find(x => x == item.Key);
                        if (data > 0)
                        {
                            var chb = lstCheckBox.Find(x => x.Text == item.Value);
                            chb.Checked = true;
                        }

                        data = -1;
                    }

                }
            }
            else
            {
                MessageBox.Show("Connection Error");
            }     
        }

        private void Reset()
        {
            txtPrice.Text = "Price";
            txtDescription.Text = "Description";
            numericCapacity.Value = 1;
            numericFloor.Value = 1;
            cmbRoomNumber.SelectedIndex = 0;
            cmbRoomType.SelectedIndex = 0;
            lstCheckBox.ForEach(x => x.Checked = false);
        }

        int RoomID = -10;

        private void dgvRoom_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvRoom.CurrentRow != null)
            {
                RoomID = Convert.ToInt32(dgvRoom["ID", dgvRoom.CurrentRow.Index].Value);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (RoomID< 0)
            {
                MessageBox.Show("Select Row");
            }
            else
            {
                var res = MessageBox.Show("Are You Sure You Want To Delete This Record ?", "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (res == DialogResult.Yes)
                {
                    if (HotelDatabase.Room.Delete(RoomID))
                    {
                        PanelStatus(panelStatusCreate ,"Action Completed Successfuly", Status.Green);

                        LoadData();

                        dgvRoom.ClearSelection();
                    }
                    else
                    {
                        PanelStatus(panelStatusCreate,"Unable to Complete Action", Status.Red);
                    }
                }
            }
        }
    }


}
