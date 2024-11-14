using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*Hozz létre egy fát és egy embert, az embernek nem kötlező hogy feje legyen  fatorzs, falomb, embertest, emberkar, emberfej
Hozz létre egy kosarat
Az ember a kosár és a fa törzse között sétál oda-vissza
Amikor a fához ér, elkezdi azt a kezével ütni. Az ütés animálása kötelező
Miután az ember 10-szer megütötte a fát, egy alma hulljon le a lombból, pont az ember kezébe. A kezénél álljon meg
Amikor megvolt a 10. ütés, nem kell többet ütni, már csak a hulló almára vár az ember
Amint elkapta az almát, visszafordul, ez lehet egy hirtelen fordulás, majd elindul almával a kezében vissza a kosárhoz
Amikor elérte a kosarat, a kezében lévő alma folytatja lefelé hullását addig, amíg a kosár teljesen el nem nyeli
Amikor a kosár elnyelte az almát, a gyűjtött almák száma eggyel nő
  Ha a gyűjtött almák száma elérte a kosár teherbírását, több almát nem tárolunk el
Amint leesett az alma és elnyelte a kosár, az ember visszafordul és újrakezdi útját

A nagyobb kosár vásárlása gomb illetve a gyorsabb szedés gomb csak akkor működik, ha van elég almánk a fejlesztés megvásárlásához.
   nagyobb kosár vásárlása esetén:
     a kosár teherbírása 5 almával nő
     a nagyobb kosár ára 2 almával nő
   gyorsabb szedés vásárlása esetén:
    az alma leszedéséhez 1-el kevesebb ütés szükséges, de minimum 3
    a gyorsabb szedés ára 30 almával nő*/


namespace fzughk_
{
    public partial class Form1 : Form
    {
        int[] positions = new int[2];
        Random r = new Random();
        Timer MozgasTimer = new Timer();
        Timer UtesTimer = new Timer();

        //Label alma = new Label();
        //this.Controls.Add(alma);
        //this.Controls.Add(ember);

        public Form1()
        {
            InitializeComponent();
            Start();

        }
        void Start()
        {
            List<PictureBox> ember = new List<PictureBox>();
            //this.Controls.Add(ember);
            //positions[0] = this.ClientSize.Width - ember.Left
            Label alma = new Label();
            this.Controls.Add(alma);
            alma.Width = 30;
            alma.Height = 30;
            alma.Left = this.ClientSize.Width / 4 + alma.Width;
            alma.Top = this.falomb.Bottom - alma.Height / 2;
            alma.BackColor = Color.Red;
            emberMozgas();
            faUtes();
        }

        void emberMozgas()
        {
            List<PictureBox> ember = new List<PictureBox>();
            ember.Add(embertest);
            ember.Add(emberkar);
            ember.Add(emberfej);

            Timer MozgasTimer = new Timer();
            MozgasTimer.Interval = 1000;
            MozgasTimer.Start();
            MozgasTimer.Tick += (s, e) =>
            {
                foreach (PictureBox item in ember)
                {
                    if (item.Visible)
                    {
                        item.Left = fatorzs.Left + fatorzs.Width - emberkar.Width;
                        //item.Left = positons[1];
                    }
                    else if (item.Visible)
                    {
                        positions[0] = kosar.Left - emberkar.Width;
                        item.Left = positions[0];
                    };
                };
            };
        }
        void faUtes()
        {
            //Timer UtesTimer = new Timer();
            UtesTimer.Start();
            UtesTimer.Tick += (ss, ee) =>
            {
                UtesTimer.Interval = 10;
            };
        }
    }
}
