namespace saldoakun
{
    public partial class Form1 : Form
    {
        Akun akun1 = new AkunPremium(20000, "hiyahiyahiya");
        public Form1()
        {
            InitializeComponent();
            label2.Text = akun1.Saldo.ToString();
        }
        private void TarikSaldo(int total)
        {
            akun1.Tarik(total);
            label2.Text = akun1.Saldo.ToString();
        }
        private void SetorSaldo(int total)
        {
            akun1.Setor(total);
            label2.Text = akun1.Saldo.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (akun1.PasswordTervalidasi(tbPassword.Text))
            {
                if (rbSetor.Checked)
                    SetorSaldo(int.Parse(tbUang.Text));
                else if (rbTarik.Checked)
                    TarikSaldo(int.Parse(tbUang.Text));
            }
            else
            {
                MessageBox.Show("Password salah");
            }
        }
    }
    public class Akun
    {
        private const int maxSaldo = 2000000;
        protected int _saldo;
        protected string password;
        public int Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                    throw new InvalidOperationException("Saldo tidak bisa kurang dari 0 rupiah");
                else if (value > maxSaldo)
                    throw new InvalidOperationException("Saldo tidak boleh melebihi 2000000 rupiah");
                else
                    _saldo = value;
            }
        }
        public Akun(int saldo, string password)
        {
            _saldo = saldo;
            this.password = password;
        }
        public virtual void Setor(int jumlah)
        {
            Saldo += jumlah;
        }
        public virtual void Tarik(int jumlah)
        {
            Saldo -= jumlah;
        }
        public bool PasswordTervalidasi(string password)
        {
            if (this.password == password)
                return true;
            else
                return false;
        }
    }
    public class AkunPremium : Akun
    {
        public AkunPremium(int saldo, string password) : base(saldo, password)
        {
            this.password = password;
            Saldo = saldo;
        }
        public new int Saldo
        {
            get
            {
                return _saldo;
            }
            set
            {
                if (value < 0)
                    throw new InvalidOperationException("Saldo tidak bisa kurang dari 0 rupiah");
                else
                    _saldo = value;
            }
        }
        public override void Setor (int jumlah)
        {
            Saldo += jumlah + 500;
        }
        public override void Tarik (int jumlah)
        {
            Saldo -= jumlah + 500;
        }
    }
}