import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
/**
 * Класс, представляющий стартовое окно приложения.
 */
public class StartWindow extends JFrame {
    /**
     * Конструктор класса Start, инициализирующий стартовое окно приложения.
     */
    public StartWindow() {
        super("StartWindow");
        this.setSize(560, 500);
        // Установка операции закрытия окна по умолчанию
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        // Запрет изменения размера окна пользователем
        this.setResizable(false);
        Timer timer = new Timer(60000, e -> dispose());// Таймер для автоматического закрытия окна через 60 секунд
        timer.start();
        setLocationRelativeTo(null);
        // Инициализация и настройка меток
        JLabel startWindowLabelData_1 = new JLabel("Беларусский национальный технический университет");
        JLabel startWindowLabelData_2 = new JLabel("Факультет информационных технологий и робототехники");
        JLabel startWindowLabelData_3 = new JLabel("Кафедра программного обеспечения информационных систем и технологий");
        JLabel startWindowLabelData_4 = new JLabel("Курсовая работа");
        JLabel startWindowLabelData_5 = new JLabel("по дисциплине \"Программирование на языке Java\"");
        JLabel startWindowLabelData_6 = new JLabel("Частотный словарь сочетаний букв алфавита");
        JLabel startWindowLabelData_7 = new JLabel("Выполнил: Студент группы 10702221");
        JLabel startWindowLabelData_8 = new JLabel("Парфенова Ульяна Дмитриевна");
        JLabel startWindowLabelData_9 = new JLabel("Преподователь: к.ф.-м.н., доц.");
        JLabel startWindowLabelData_10 = new JLabel("Сидорик Валерий Владимирович");
        JLabel startWindowLabelData_11 = new JLabel("Минск, 2023");
        // Настройка шрифта для меток
        Font startWindowLabelFont_1 = new Font("Times New Roman", Font.BOLD, 14);
        Font startWindowLabelFont_2 = new Font("Times New Roman", Font.BOLD, 20);
        Font startWindowLabelFont_3 = new Font("Times New Roman", Font.BOLD, 18);
        // Установка шрифта для меток
        startWindowLabelData_1.setFont(startWindowLabelFont_1);
        startWindowLabelData_2.setFont(startWindowLabelFont_1);
        startWindowLabelData_3.setFont(startWindowLabelFont_1);
        startWindowLabelData_4.setFont(startWindowLabelFont_2);
        startWindowLabelData_5.setFont(startWindowLabelFont_3);
        startWindowLabelData_6.setFont(startWindowLabelFont_2);
        startWindowLabelData_7.setFont(startWindowLabelFont_1);
        startWindowLabelData_8.setFont(startWindowLabelFont_1);
        startWindowLabelData_9.setFont(startWindowLabelFont_1);
        startWindowLabelData_10.setFont(startWindowLabelFont_1);
        startWindowLabelData_11.setFont(startWindowLabelFont_1);

        // Создание кнопок
        JButton start = new JButton("Next");
        JButton stop = new JButton("Exit");

        // Создание панели для компоновки компонентов
        JPanel startWindowPanel = new JPanel();

        // Установка менеджера компоновки в null, что позволяет явно задавать позиции компонентов
        startWindowPanel.setLayout(null);

        // Установка расположения меток
        startWindowLabelData_1.setBounds(80, 10, 370, 20);
        startWindowLabelData_2.setBounds(75, 30, 400, 20);
        startWindowLabelData_3.setBounds(15, 50, 520, 20);
        startWindowLabelData_4.setBounds(200, 150, 150, 20);
        startWindowLabelData_5.setBounds(50, 175, 450, 20);
        startWindowLabelData_6.setBounds(70, 200, 420, 20);
        startWindowLabelData_7.setBounds(280, 250, 250, 20);
        startWindowLabelData_8.setBounds(280, 270, 280, 20);
        startWindowLabelData_9.setBounds(280, 310, 250, 20);
        startWindowLabelData_10.setBounds(280, 330, 250, 20);
        startWindowLabelData_11.setBounds(225, 400, 100, 20);
        start.setBounds(4, 430, 271, 25);
        stop.setBounds(275, 430, 271, 25);
        // Добавление меток в панель
        startWindowPanel.add(startWindowLabelData_1);
        startWindowPanel.add(startWindowLabelData_2);
        startWindowPanel.add(startWindowLabelData_3);
        startWindowPanel.add(startWindowLabelData_4);
        startWindowPanel.add(startWindowLabelData_5);
        startWindowPanel.add(startWindowLabelData_6);
        startWindowPanel.add(startWindowLabelData_7);
        startWindowPanel.add(startWindowLabelData_8);
        startWindowPanel.add(startWindowLabelData_9);
        startWindowPanel.add(startWindowLabelData_10);
        startWindowPanel.add(startWindowLabelData_11);
        startWindowPanel.add(start);
        startWindowPanel.add(stop);
        this.add(startWindowPanel);
        this.setVisible(true);

        // Создание метки для отображения изображения
        JLabel icon = new JLabel();
        ImageIcon img = new ImageIcon("src/images/Start1.png");
        // Установка изображения для метки
        icon.setIcon(img);
        // Установка позиции и размеров метки на панели
        icon.setBounds(50, 240, 190, 100);
        startWindowPanel.add(icon);

        // Добавление обработчиков событий для кнопок
        start.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                // Скрыть стартовое окно
                setVisible(false);
                Application.runApplication();
            }
        });
        stop.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                // Закрыть стартовое окно
                dispose();
            }
        });

    }
    /**
     * Точка входа в приложение. Создает экземпляр StartWindow.
     *
     * @param args Аргументы командной строки (не используются).
     */
    public static void main(String[] args) {
        new StartWindow();
    }
}