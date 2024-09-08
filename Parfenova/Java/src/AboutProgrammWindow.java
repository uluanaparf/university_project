/**
 * Класс AboutProgrammWindow представляет окно "О программе" с информацией о программе.
 * @version 1.0
 * @author Парфенова Ульяна Дмитриевна
 */
import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

/**
 * Класс, представляющий окно "О программе" с информацией о программе.
 */
public class AboutProgrammWindow extends JFrame {

    /**
     * Конструктор класса AboutProgrammWindow, инициализирующий окно "О программе".
     */
    public AboutProgrammWindow() {
        super("About Program");
        setSize(720, 300);
        setResizable(false);
        setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE); // Close only this window
        setLayout(null);
        setLocationRelativeTo(null);

        Font aboutProgramWindowFont_1 = new Font("Times New Roman", Font.BOLD, 14);

        JLabel lblNameOfProgram = new JLabel("Частотный словарь сочетаний букв алфавита");
        JLabel lblAboutProgramAbility = new JLabel("Программа позволяет:");
        JLabel lblAboutEaseEnteringData = new JLabel("1.Анализировать данные о количестве букв в тексте, введенном пользователем ");
        JLabel lblAboutEaseContainData = new JLabel("2.Искать данный в тексте, введеном пользователем");
        JLabel lblAboutEaseGraphicData = new JLabel("3. Создавать графики для графического отображения частоты использования букв в тексте");
        JLabel lblAboutEaseDownloadData = new JLabel("4. Загружать и сохранять полученные данные");

        setFont(aboutProgramWindowFont_1);

        lblNameOfProgram.setBounds(200, 30, 300, 20);
        lblAboutProgramAbility.setBounds(200, 70, 500, 20);
        lblAboutEaseEnteringData.setBounds(200, 85, 500, 20);
        lblAboutEaseContainData.setBounds(200, 100, 500, 20);
        lblAboutEaseGraphicData.setBounds(200, 115, 500, 20);
        lblAboutEaseDownloadData.setBounds(200,130,500,20);

        JLabel lblIcon = new JLabel();
        ImageIcon img = new ImageIcon("src/images/Program.png");
        lblIcon.setIcon(img);
        lblIcon.setBounds(20, 50, 150, 150);

        TextArea textVersion = new TextArea();
        textVersion.setEditable(false);
        textVersion.setText("Версия ver.1.0.0.2023");
        textVersion.setBounds(200, 240, 280, 20);

        JButton btnBack = new JButton("Назад");
        btnBack.setBounds(480, 240, 100, 20);
        btnBack.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                // При нажатии на "Назад" делаем окно "О программе" невидимым
                setVisible(false);
                Application.runApplication();
            }
        });

        add(lblNameOfProgram);
        add(lblAboutProgramAbility);
        add(lblAboutEaseEnteringData);
        add(lblAboutEaseContainData);
        add(lblAboutEaseGraphicData);
        add(lblAboutEaseDownloadData);
        add(lblIcon);
        add(textVersion);
        add(btnBack);
        setVisible(true);
    }
}
