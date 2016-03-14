using System;
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Imaging;
using System.Threading;
using System.IO;
using System.Net;
using System.Runtime.InteropServices;
using System.Web.Script.Serialization;
using FC.GEPluginCtrls;

namespace GEView
{
    [System.Runtime.InteropServices.ComVisibleAttribute(true)]

    public partial class GEView : Form
    {
        private dynamic ge;
        public byte[] bmask_equ;
        public byte[] bmask_ortho;
        public Bitmap cap;
        public Bitmap fish;
        public Bitmap fish_el;
        public Bitmap bw;
        public double lat, lon, alt, head, tilt, roll, fov;
        public bool initflag = false;
        public bool ortho = false;
        public int altmode;
        public string altmodestr;
        public double dalt = 0.0;

        public GEView()
        {
            InitializeComponent();
            
            wb_gm.ObjectForScripting = this;
            wb_gm.Navigate(Path.Combine(Environment.CurrentDirectory, "gmap.html"));

            gwb_ge.LoadEmbeddedPlugin();

            // Handle the he PluginReady event 
            gwb_ge.PluginReady += (o, e) =>
            {
                ge = e.ApiObject;
                ge.getOptions().setFadeInOutEnabled(false);
                ge.getOptions().setFlyToSpeed(ge.SPEED_TELEPORT);
                ge.getLayerRoot().enableLayerById(ge.LAYER_TERRAIN, 1);
                ge.getLayerRoot().enableLayerById(ge.LAYER_BUILDINGS, 1);
                altmode = ge.ALTITUDE_RELATIVE_TO_GROUND;
                altmodestr = "relativeToGround";
                b_init.Enabled = true;
                b_kml.Enabled = true;
                rb_abs.Enabled = true;
                rb_ell.Enabled = true;
                rb_rel.Enabled = true;
            };

            // handle any script errors
            gwb_ge.ScriptError += (o, e) =>
            {
                MessageBox.Show(e.Message, e.Data);
            };

            Bitmap mask_equ = Properties.Resources.mask_equ;
            BitmapData maskdata_equ = mask_equ.LockBits(
                            new Rectangle(0, 0, mask_equ.Width, mask_equ.Height),
                            ImageLockMode.ReadWrite,
                            PixelFormat.Format24bppRgb);
            bmask_equ = new byte[mask_equ.Width * mask_equ.Height * 3];
            Marshal.Copy(maskdata_equ.Scan0, bmask_equ, 0, bmask_equ.Length);

            Bitmap mask_ortho = Properties.Resources.mask_ortho;
            BitmapData maskdata_ortho = mask_ortho.LockBits(
                            new Rectangle(0, 0, mask_ortho.Width, mask_ortho.Height),
                            ImageLockMode.ReadWrite,
                            PixelFormat.Format24bppRgb);
            bmask_ortho = new byte[mask_ortho.Width * mask_ortho.Height * 3];
            Marshal.Copy(maskdata_ortho.Scan0, bmask_ortho, 0, bmask_ortho.Length);

            cap = new Bitmap(gwb_ge.Width, gwb_ge.Height, PixelFormat.Format24bppRgb);
            fish = new Bitmap(pb_fish.Width, pb_fish.Height, PixelFormat.Format24bppRgb);
            fish_el = new Bitmap(pb_fish.Width, pb_fish.Height, PixelFormat.Format24bppRgb);
            bw = new Bitmap(pb_fish.Width, pb_fish.Height, PixelFormat.Format8bppIndexed);
        }

        private string create_camera_kml(double lat, double lon, double alt, double head, double tilt, double roll, double fov, string altmodestr)
        {
            string kml = "<?xml version='1.0' encoding='UTF-8'?><kml xmlns='http://www.opengis.net/kml/2.2' xmlns:gx='http://www.google.com/kml/ext/2.2' xmlns:kml='http://www.opengis.net/kml/2.2' xmlns:atom='http://www.w3.org/2005/Atom'><gx:Tour><name>";
            kml += "</name><gx:Playlist><gx:FlyTo><gx:duration>0.0</gx:duration><gx:flyToMode>smooth</gx:flyToMode><Camera>";
            kml += "<longitude>" + lon.ToString() + "</longitude>";
            kml += "<latitude>" + lat.ToString() + "</latitude>";
            kml += "<altitude>" + alt.ToString() + "</altitude>";
            kml += "<heading>" + head.ToString() + "</heading>";
            kml += "<tilt>" + tilt.ToString() + "</tilt>";
            kml += "<roll>" + roll.ToString() + "</roll>";
            kml += "<gx:horizFov>" + fov.ToString() + "</gx:horizFov>";
            kml += "<gx:altitudeMode>" + altmodestr + "</gx:altitudeMode></Camera></gx:FlyTo></gx:Playlist></gx:Tour></kml>";
            return kml;
        }

        private void set_camera_kml()
        {
            // Wait loading...
            var camera = ge.getView().copyAsCamera(altmode);
            camera.set(lat, lon, 300.0, altmode, head, 0.0, roll);
            ge.getView().setAbstractView(camera);

            MessageBox.Show("Click \"OK\" after loading all 3D city models...");

            string kmlstr = create_camera_kml(lat,lon,alt,head,tilt,roll,fov,altmodestr);
            ge.getTourPlayer().setTour(gwb_ge.ParseKml(kmlstr));
            ge.getTourPlayer().setTour(gwb_ge.ParseKml(kmlstr));
            Thread.Sleep(500);
            ge.getTourPlayer().setTour(null);
            ge.getTourPlayer().setTour(null);
        }

        private void set_camera()
        {
            Thread th_set_camera = new Thread(new ThreadStart(_set_camera));
            th_set_camera.Start();
            th_set_camera.Join();
        }

        private void _set_camera()
        {
            var camera = ge.getView().copyAsCamera(altmode);
            camera.set(lat, lon, alt, altmode, head, tilt, roll);
            ge.getView().setAbstractView(camera);
            Thread.Sleep(50);
        }

        private void b_init_Click(object sender, EventArgs e)
        {
            b_init.Enabled = false;

            lat = double.Parse(tb_lat.Text);
            lon = double.Parse(tb_lon.Text);
            alt = double.Parse(tb_alt.Text);
            head = double.Parse(tb_head.Text);
            tilt = double.Parse(tb_tilt.Text);
            roll = double.Parse(tb_roll.Text);
            fov = double.Parse(tb_fov.Text);

            if (rb_ell.Checked) alt -= get_geoidh(lat, lon);

            set_camera_kml();

            cap = gwb_ge.ScreenGrab();
            update_fish();

            if (cb_line.Checked) plot_elevation();

            b_init.Enabled = true;
            b_cap.Enabled = true;
            b_csv.Enabled = true;
            b_update.Enabled = true;
            initflag = true;
        }

        private void b_cap_Click(object sender, EventArgs e)
        {
            saveFileDialog.Title = "Input file name";
            saveFileDialog.FileName = "geview_fish.jpg";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK)
            {
                Thread.Sleep(500);
                try
                {
                    if (cb_line.Checked) fish_el.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                    else fish.Save(saveFileDialog.FileName, ImageFormat.Jpeg);
                    
                    generate_bw();
                    bw.Save(saveFileDialog.FileName.Replace("_fish.jpg", "_bw.jpg"), ImageFormat.Jpeg);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message); 
                }
            }
        }

        private void b_csv_Click(object sender, EventArgs e)
        {
            openFileDialog.Title = "Select csv file";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                folderBrowserDialog.SelectedPath = Path.GetDirectoryName(openFileDialog.FileName);
                if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        using (var sr = new StreamReader(openFileDialog.FileName))
                        {
                            int cnt = 1;
                            double oldlat = 0, oldlon = 0;
                            while (!sr.EndOfStream)
                            {
                                var line = sr.ReadLine();
                                var values = line.Split(',');

                                lat = double.Parse(values[0]);
                                lon = double.Parse(values[1]);
                                alt = double.Parse(values[2]);
                                tilt = 180;
                                roll = 0;
                                head = double.Parse(values[3]);
                                fov = 160.0;

                                if (Math.Abs(lat - oldlat) > 1e-7 || Math.Abs(lon - oldlon) > 1e-7)
                                {
                                    update_view();
                                    update_fish();
                                    if (cb_line.Checked) plot_elevation();
                                }
                                
                                string fname = "geview_fish_" + cnt.ToString("D5") + "_fov" + fov.ToString() + ".jpg";
                                string fpath = Path.Combine(folderBrowserDialog.SelectedPath, fname);
                                fish.Save(fpath, ImageFormat.Jpeg);
                                generate_bw();
                                bw.Save(fpath.Replace("_fish", "_bw"), ImageFormat.Jpeg);

                                oldlat = lat;
                                oldlon = lon;
                                cnt++;
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }
            }
        }

        private void generate_bw()
        {
            BitmapData fishdata = fish.LockBits(
                            new Rectangle(0, 0, fish.Width, fish.Height),
                            ImageLockMode.ReadWrite,
                            PixelFormat.Format24bppRgb);
            byte[] bfish = new byte[fish.Width * fish.Height * 3];
            Marshal.Copy(fishdata.Scan0, bfish, 0, bfish.Length);
            fish.UnlockBits(fishdata);

            BitmapData bwdata = bw.LockBits(
                new Rectangle(0, 0, bw.Width, bw.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format8bppIndexed);
            byte[] bbw = new byte[bw.Width * bw.Height];

            for (int i = 0; i < bbw.Length; i++)
            {
                double dr, dg, db;
                if (ortho)
                {
                    dr = Math.Abs(bmask_ortho[3*i+0]-bfish[3*i+0]);
                    dg = Math.Abs(bmask_ortho[3*i+1]-bfish[3*i+1]);
                    db = Math.Abs(bmask_ortho[3*i+2]-bfish[3*i+2]);
                }
                else
                {
                    dr = Math.Abs(bmask_equ[3*i+0]-bfish[3*i+0]);
                    dg = Math.Abs(bmask_equ[3 * i + 1] - bfish[3 * i + 1]);
                    db = Math.Abs(bmask_equ[3 * i + 2] - bfish[3 * i + 2]);
                }

                if (dr<5 && dr<5 && db<5) 
                {
                    bbw[i] = 255;
                }
                else
                {
                    bbw[i] = 0;
                }
            }
            Marshal.Copy(bbw, 0, bwdata.Scan0, bbw.Length);
            bw.UnlockBits(bwdata);
        }

        private void update_view()
        {
            set_camera();
            Thread.Sleep(50);
            cap = gwb_ge.ScreenGrab();
        }
        
        private void update_fish()
        {
            BitmapData capdata = cap.LockBits(
                new Rectangle(0, 0, cap.Width, cap.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);
            byte[] bcap = new byte[cap.Width * cap.Height * 3];
            Marshal.Copy(capdata.Scan0, bcap, 0, bcap.Length);
            cap.UnlockBits(capdata);

            BitmapData fishdata = fish.LockBits(
                new Rectangle(0, 0, fish.Width, fish.Height),
                ImageLockMode.ReadWrite,
                PixelFormat.Format24bppRgb);
            byte[] bfish = new byte[fish.Width * fish.Height * 3];
            
            double f = (cap.Width / 2) / Math.Tan(fov / 2 * Math.PI / 180);

            for (int i = 0; i < bfish.Length; )
            {
                double x = (i/3)%fish.Width - fish.Width/2;
                double y = (int)((i/3)/fish.Width) - fish.Height/2;
                double r = Math.Sqrt(x*x+y*y);
                double el;
                if (ortho) el = Math.Acos(r / (fish.Height / 2));
                else el = Math.PI / 2 * (1 - r / (fish.Height / 2));
                double theta = Math.Atan2(y, x);

                double r2 = f * Math.Tan(Math.PI/2-el);
                double x2 = Math.Floor(r2 * Math.Cos(theta) + cap.Width / 2);
                double y2 = Math.Floor(r2 * Math.Sin(theta) + cap.Height / 2);
                int i2 = (int)(3*(x2 + y2 * cap.Width));

                bool eval;
                if (ortho) eval = r > (fish.Height / 2) || el < (Math.PI - fov / 180 * Math.PI) / 2;
                else eval = r2 < 0 || r2 >= (cap.Width / 2);
                if (eval)
                {
                    bfish[i] = 0; i++;
                    bfish[i] = 0; i++;
                    bfish[i] = 0; i++;
                }
                else
                {
                    bfish[i] = bcap[i2]; i++; i2++;
                    bfish[i] = bcap[i2]; i++; i2++;
                    bfish[i] = bcap[i2]; i++; i2++;
                }
            }
            Marshal.Copy(bfish, 0, fishdata.Scan0, bfish.Length);
            fish.UnlockBits(fishdata);

            pb_fish.Image = fish;
            pb_fish.Refresh();
        }

        private void update_viewfish()
        {
            lat = double.Parse(tb_lat.Text);
            lon = double.Parse(tb_lon.Text);
            alt = double.Parse(tb_alt.Text);
            head = double.Parse(tb_head.Text);
            tilt = double.Parse(tb_tilt.Text);
            roll = double.Parse(tb_roll.Text);
            fov = double.Parse(tb_fov.Text);

            if (initflag)
            {
                update_view();
                update_fish();
            }
        }

        private void gm_setcent(double lat, double lon)
        {
            Object[] obj = new Object[2];
            obj[0] = lat.ToString();
            obj[1] = lon.ToString();
            wb_gm.Document.InvokeScript("SetCent", obj);
        }

        private void gm_addmark(double lat, double lon)
        {
            Object[] obj = new Object[2];
            obj[0] = lat.ToString();
            obj[1] = lon.ToString();
            wb_gm.Document.InvokeScript("AddMark", obj);
        }

        private void gm_posmark(double lat, double lon)
        {
            Object[] obj = new Object[2];
            obj[0] = lat.ToString();
            obj[1] = lon.ToString();
            wb_gm.Document.InvokeScript("PosMark", obj);
        }
        
        private double get_geoidh(double lat, double lon)
        {
            string url = "http://www.taroz.net/api/geoid.py?lat=" + lat.ToString() + "&lon=" + lon.ToString();
            var req = WebRequest.Create(url);
            var res = req.GetResponse();
            Geoid geoid;

            using (var reader = new StreamReader(res.GetResponseStream()))
            {
                JavaScriptSerializer js = new JavaScriptSerializer();
                string objText = reader.ReadToEnd();
                geoid = (Geoid)js.Deserialize(objText, typeof(Geoid));
            }
            return double.Parse(geoid.geoid);
        }

        public void setLatLon()
        {
            gm_setcent(double.Parse(tb_lat.Text), double.Parse(tb_lon.Text));
            gm_addmark(double.Parse(tb_lat.Text), double.Parse(tb_lon.Text));
        }

        public void setTextBox(double lat, double lon)
        {
            tb_lat.Text = lat.ToString();
            tb_lon.Text = lon.ToString();

            update_viewfish();
            if (cb_line.Checked) plot_elevation();
        }

        private void rb_ortho_CheckedChanged(object sender, EventArgs e)
        {
            ortho = true;
            update_viewfish();
            if (cb_line.Checked) plot_elevation();
        }

        private void rb_equ_CheckedChanged(object sender, EventArgs e)
        {
            ortho = false;
            update_viewfish();
            if (cb_line.Checked) plot_elevation();
        }

        private void b_update_Click(object sender, EventArgs e)
        {
            update_viewfish();
            if (cb_line.Checked) plot_elevation();
        }

        private void cb_line_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_line.Checked)
            {
                plot_elevation();
            }
            else
            {
                pb_fish.Image = fish;
            }
        }

        private void plot_elevation()
        {
            Pen p = new Pen(Color.FromArgb(128, Color.Red), 2);
            fish_el = new Bitmap(fish);
            Graphics g = Graphics.FromImage(fish_el);

            for (int i = 0; i < 9; i++)
            {
                int e;
                if (ortho) e = (int)((double)fish.Width * Math.Cos(10 * i / 180.0 * Math.PI));
                else e = (int)(fish.Width - fish.Width / 9 * i);
                int d = (int)((fish.Width - e) / 2);
                g.DrawEllipse(p, d, d, e, e);
            }

            g.Dispose();
            p.Dispose();
            pb_fish.Image = fish_el;
        }

        private void rb_rel_CheckedChanged(object sender, EventArgs e)
        {
            altmode = ge.ALTITUDE_RELATIVE_TO_GROUND;
            altmodestr = "relativeToGround";
        }

        private void rb_abs_CheckedChanged(object sender, EventArgs e)
        {
            altmode = ge.ALTITUDE_ABSOLUTE;
            altmodestr = "absolute";
        }

        private void rb_ell_CheckedChanged(object sender, EventArgs e)
        {
            altmode = ge.ALTITUDE_ABSOLUTE;
            altmodestr = "absolute";
        }

        private void cb_3D_CheckedChanged(object sender, EventArgs e)
        {
            if (cb_3D.Checked)
            {
                ge.getLayerRoot().enableLayerById(ge.LAYER_BUILDINGS, 1);
                ge.getLayerRoot().enableLayerById(ge.LAYER_TERRAIN, 1);
            }
            else
            {
                ge.getLayerRoot().enableLayerById(ge.LAYER_BUILDINGS, 0);
                ge.getLayerRoot().enableLayerById(ge.LAYER_TERRAIN, 0);
            }
        }

        private void b_kml_Click(object sender, EventArgs e)
        {
            if (openKmlDialog.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    dynamic kml = gwb_ge.FetchKmlLocal(openKmlDialog.FileName);
                    ge.getFeatures().appendChild(kml);
                    var view = kml.getAbstractView();
                    if (view!=null)
                    {
                        cb_3D.Checked = false;
                        ge.getView().setAbstractView(view);
                        var look = view.copyAsLookAt();
                        lat = look.getLatitude();
                        lon = look.getLongitude();
                        tb_lat.Text = lat.ToString();
                        tb_lon.Text = lon.ToString();
                        gm_setcent(lat, lon);
                        gm_posmark(lat, lon);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }

    public class Geoid
    {
        public string lat { get; set; }
        public string lon { get; set; }
        public string geoid { get; set; }
    }
}
