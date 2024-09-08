import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;

/**
 * Класс AboutAuthorWindow представляет окно с информацией об авторе.
 */
public class AboutAuthorWindow  {

    /**
     * Отображает окно с информацией об авторе.
     */
    public void aboutAuthor() {
        JFrame frame = new JFrame("About the author");

        // Установка менеджера компоновки
        frame.setLayout(new BorderLayout());

        // Добавление фотографии
        JPanel imagePanel = new JPanel(new FlowLayout(FlowLayout.CENTER));
        ImageIcon icon = new ImageIcon("src/images/Author.jpg");
        icon = new ImageIcon(icon.getImage().getScaledInstance(230, 256, Image.SCALE_SMOOTH));
        JLabel imageLabel = new JLabel(icon);
        imagePanel.add(imageLabel);
        frame.add(imagePanel, BorderLayout.NORTH);

        // Создание панели для компонентов
        JPanel componentsPanel = new JPanel();
        componentsPanel.setLayout(new BoxLayout(componentsPanel, BoxLayout.Y_AXIS));
        componentsPanel.setAlignmentX(Component.CENTER_ALIGNMENT);

        // Full name
        JLabel nameLabel = new JLabel("ФИО: Парфенова Ульяна Дмитриевна");
        nameLabel.setAlignmentX(Component.CENTER_ALIGNMENT);
        componentsPanel.add(nameLabel);

        // Номер учебной группы
        JLabel groupLabel = new JLabel("Группа: 10702221");
        groupLabel.setAlignmentX(Component.CENTER_ALIGNMENT);
        componentsPanel.add(groupLabel);

        // Mail
        JLabel mailLabel = new JLabel("uly.parfenova@gmail.com");
        mailLabel.setAlignmentX(Component.CENTER_ALIGNMENT);
        componentsPanel.add(mailLabel);

        frame.add(componentsPanel, BorderLayout.CENTER);
        componentsPanel.add(Box.createVerticalStrut(20));

        // Button
        JButton backButton = new JButton("Назад");
        backButton.setAlignmentX(Component.CENTER_ALIGNMENT);
        backButton.addActionListener(e -> frame.dispose());
        componentsPanel.add(backButton);

        backButton.addActionListener(new ActionListener() {
            @Override
            public void actionPerformed(ActionEvent e) {
                // При нажатии на "Назад" делаем окно "О программе" невидимым
                frame.setVisible(false);
                Application.runApplication();
            }
        });

        // Установка свойств окна
        frame.setSize(280, 420);
        frame.setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);
        frame.setResizable(false);
        frame.setLocationRelativeTo(null);
        frame.setVisible(true);
    }
}
