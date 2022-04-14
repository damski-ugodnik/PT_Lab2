namespace PT_Lab2
{
    /// <summary>
    /// класс начальной формы, в программе она одна и она является основной программой запускающей другие, она является отправной точкой работы программы
    /// </summary>
    public partial class StartForm : Form
    {
        /// <summary>
        /// переменная класса Form, в которой хранится экземпляр формы для квадратного уравнения либо кубического
        /// </summary>
        private static Form? frm;

        public StartForm()
        {
            InitializeComponent();
        }

        private void StartForm_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// кнопка запуска формы для решения квадртаного уравнения
        /// когда открывается форма, стартовое окно прячется
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void SquareEq_Button_Click(object sender, EventArgs e)
        {
            frm = new SquareEq();// создание экземпляра формы
            frm.Location = this.Location;//расположение новой формы равно расположению текущей формы
            frm.StartPosition = FormStartPosition.Manual;
            frm.Show();// показ новой формы
            this.Hide();// скрытие начальной формы
        }
        /// <summary>
        /// кнопка запуска формы для решения кубического уравнения
        /// когда открывается форма, стартовое окно прячется
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CubicEq_Button_Click(object sender, EventArgs e)
        {

            frm = new CubicEq();// создание экземпляра формы
            frm.Location = this.Location;//расположение новой формы равно расположению текущей формы
            frm.StartPosition = FormStartPosition.Manual;
            frm.Show();// показ новой формы
            this.Hide();// скрытие начальной формы
        }
        /// <summary>
        /// текущая форма для решения уравнения
        /// при переопределении предыдущая форма удаляется
        /// </summary>
        /// <exception cref="NullReferenceException"></exception>
        public static Form CurrentForm
        {
            get
            {
                if (frm == null)
                {
                    throw new NullReferenceException();
                }
                return frm;
            }
            set
            {
                if (frm != null)
                    frm.Close();
                frm = value;
            }
        }
    }
}
