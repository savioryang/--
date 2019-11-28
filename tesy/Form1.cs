using log4net;
using LogR;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tesy
{
    public partial class Form1 : Form
    {
        private static ILog log = LogManager.GetLogger(typeof(Form1));
        public Form1()
        {
            InitializeComponent();
            log4net.Config.XmlConfigurator.Configure();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            log.Info("chengxukaishi");
        }
    }
}
