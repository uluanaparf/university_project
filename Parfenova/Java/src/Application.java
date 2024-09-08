import javax.swing.*;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.io.*;

/**
 * Главный класс приложения, представляющий текстовый анализатор.
 */
public class Application extends JFrame {

    private JTextArea textArea;
    private JTextArea resultArea;
    private JTextField searchField;
    private ChartWindow chartWindow;

    /**
     * Конструктор класса Application, инициализирующий главное окно приложения.
     */
    public Application() {
        super("Main Application");
        setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        setSize(800, 600);
        setLayout(new BorderLayout());

        // Инициализация верхней панели
        JPanel topPanel = new JPanel();
        topPanel.setLayout(new FlowLayout(FlowLayout.LEFT));

        // Инициализация меню
        JMenuBar menuBar = new JMenuBar();
        setJMenuBar(menuBar);

        // Меню "Файл"
        JMenu fileMenu = new JMenu("Файл");
        menuBar.add(fileMenu);

        JMenuItem exitMenuItem = new JMenuItem("Выход");
        exitMenuItem.addActionListener(e -> System.exit(0));
        fileMenu.add(exitMenuItem);

        // Меню "О программе"
        JMenu aboutMenu = new JMenu("О программе");
        menuBar.add(aboutMenu);

        JMenuItem aboutProgramMenuItem = new JMenuItem("О программе");
        aboutProgramMenuItem.addActionListener(e -> {
            AboutProgrammWindow aboutProgramMenu = new AboutProgrammWindow();
            setVisible(false);
        });
        aboutMenu.add(aboutProgramMenuItem);

        JMenuItem aboutAuthorMenuItem = new JMenuItem("Об авторе");
        aboutAuthorMenuItem.addActionListener(e -> {
            AboutAuthorWindow aboutAuthorMenu = new AboutAuthorWindow();
            aboutAuthorMenu.aboutAuthor();
            setVisible(false);
        });
        aboutMenu.add(aboutAuthorMenuItem);

        // Меню "Помощь"
        JMenu HelpMenu = new JMenu("Помощь");
        menuBar.add(HelpMenu);

        // Добавление верхней панели
        add(topPanel, BorderLayout.NORTH);

        // Инициализация текстовой области
        textArea = new JTextArea();
        textArea.setLineWrap(true);
        textArea.setWrapStyleWord(true);
        JScrollPane textScrollPane = new JScrollPane(textArea, JScrollPane.VERTICAL_SCROLLBAR_ALWAYS, JScrollPane.HORIZONTAL_SCROLLBAR_NEVER);
        add(textScrollPane, BorderLayout.CENTER);

        // Инициализация области результата
        resultArea = new JTextArea();
        JScrollPane resultScrollPane = new JScrollPane(resultArea);
        resultScrollPane.setPreferredSize(new Dimension(getWidth() * 40 / 100, getHeight() * 40 / 100));

        // Панель для кнопки "Open"
        JPanel openPanel = new JPanel();
        JButton openButton = new JButton("Открыть");
        openPanel.add(openButton);

        // Панель для кнопки "Save"
        JPanel savePanel = new JPanel();
        JButton saveButton = new JButton("Сохранить");
        savePanel.add(saveButton);

        // Панель с кнопками "Find", "Analyze", "График"
        JPanel bottomPanel = new JPanel();
        bottomPanel.setLayout(new FlowLayout(FlowLayout.LEFT));

        JButton findButton = new JButton("Найти");
        JButton analyzeButton = new JButton("Анализировать");
        JButton chartButton = new JButton("График");
        JButton exitButton = new JButton("Выход");

        searchField = new JTextField();
        searchField.setPreferredSize(new Dimension(getWidth() * 30 / 100, 30));

        bottomPanel.add(searchField);
        bottomPanel.add(findButton);
        bottomPanel.add(analyzeButton);
        bottomPanel.add(chartButton);
        bottomPanel.add(saveButton);
        bottomPanel.add(exitButton);

        // Добавление компонентов на окно
        add(topPanel, BorderLayout.NORTH);
        add(textScrollPane, BorderLayout.CENTER);
        add(openPanel, BorderLayout.WEST);
        add(resultScrollPane, BorderLayout.EAST);
        add(bottomPanel, BorderLayout.SOUTH);

        // Обработчики событий
        openButton.addActionListener(e -> openFile());
        saveButton.addActionListener(e -> saveResult());
        exitButton.addActionListener(e -> System.exit(0));

        textArea.setText("Текст из файла или введите текст здесь.");

        SearchFunction search = new SearchFunction(textArea);
        findButton.addActionListener(e -> {
            String searchTerm = searchField.getText();
            search.highlightText(searchTerm);
        });

        analyzeButton.addActionListener(e -> {
            String[] options = {"По алфавиту", "По убыванию"};
            int choice = JOptionPane.showOptionDialog(
                    Application.this,
                    "Выберите порядок сортировки:",
                    "Анализ",
                    JOptionPane.DEFAULT_OPTION,
                    JOptionPane.QUESTION_MESSAGE,
                    null,
                    options,
                    options[0]
            );
            String text = textArea.getText();
            String result;

            if (choice == 0) {
                result = TextAnalyzerHelper.analyzeAlphabeticalOrder(text);
            } else if (choice == 1) {
                result = TextAnalyzerHelper.analyzeReverseOrder(text);
            } else {
                result = ""; // Добавьте обработку других вариантов
            }
            resultArea.setText(result);
        });

        chartButton.addActionListener(e -> {
            if (chartWindow == null) {
                chartWindow = new ChartWindow(TextAnalyzerHelper.countLetters(textArea.getText()));
                chartWindow.displayChart();
            }
        });
    }

    /**
     * Метод для открытия файла и загрузки его содержимого в текстовую область.
     */
    private void openFile() {
        JFileChooser fileChooser = new JFileChooser();
        int result = fileChooser.showOpenDialog(Application.this);

        if (result == JFileChooser.APPROVE_OPTION) {
            File selectedFile = fileChooser.getSelectedFile();

            try (BufferedReader reader = new BufferedReader(new FileReader(selectedFile))) {
                StringBuilder content = new StringBuilder();
                String line;
                while ((line = reader.readLine()) != null) {
                    content.append(line).append("\n");
                }
                textArea.setText(content.toString());
            } catch (IOException e) {
                e.printStackTrace();
                JOptionPane.showMessageDialog(
                        Application.this,
                        "Ошибка при чтении файла",
                        "Ошибка",
                        JOptionPane.ERROR_MESSAGE
                );
            }
        }
    }

    /**
     * Метод для сохранения содержимого результата в файл.
     */
    private void saveResult() {
        JFileChooser fileChooser = new JFileChooser();
        int result = fileChooser.showSaveDialog(Application.this);

        if (result == JFileChooser.APPROVE_OPTION) {
            File selectedFile = fileChooser.getSelectedFile();

            try (PrintWriter writer = new PrintWriter(selectedFile)) {
                writer.print(resultArea.getText());
                JOptionPane.showMessageDialog(
                        Application.this,
                        "Результат сохранен успешно",
                        "Сохранение",
                        JOptionPane.INFORMATION_MESSAGE
                );
            } catch (FileNotFoundException e) {
                e.printStackTrace();
                JOptionPane.showMessageDialog(
                        Application.this,
                        "Ошибка при сохранении файла",
                        "Ошибка",
                        JOptionPane.ERROR_MESSAGE
                );
            }
        }
    }

    /**
     * Статический метод для запуска приложения, вызывается из класса StartWindow.
     */
    public static void runApplication() {
        SwingUtilities.invokeLater(() -> {
            Application application = new Application();
            application.setVisible(true);
        });
    }
}
