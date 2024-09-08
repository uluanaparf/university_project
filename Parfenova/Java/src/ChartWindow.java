import javax.swing.*;
import java.awt.*;
import java.util.Map;

/**
 * Класс ChartWindow представляет окно с графиком частоты букв.
 */
public class ChartWindow extends JFrame {

    private Map<Character, Integer> letterCount;

    /**
     * Конструктор класса ChartWindow.
     *
     * @param letterCount Карта, содержащая частоту каждой буквы.
     */
    public ChartWindow(Map<Character, Integer> letterCount) {
        this.letterCount = letterCount;

        setTitle("График частоты букв");
        setSize(400, 400);  // Увеличил высоту окна
        setDefaultCloseOperation(JFrame.DISPOSE_ON_CLOSE);

        JPanel chartPanel = new JPanel() {
            @Override
            protected void paintComponent(Graphics g) {
                super.paintComponent(g);
                drawChart(g);
            }
        };

        chartPanel.setPreferredSize(new Dimension(400, 300));
        add(chartPanel);
    }

    /**
     * Отображает окно с графиком частоты букв.
     */
    public void displayChart() {
        SwingUtilities.invokeLater(() -> {
            setVisible(true);
            repaint();
        });
    }

    /**
     * Рисует график частоты букв.
     *
     * @param g Графический контекст.
     */
    private void drawChart(Graphics g) {
        if (letterCount != null) {
            int maxHeight = getHeight() - 70;
            int barWidth = 20;
            int x = 30;

            for (Map.Entry<Character, Integer> entry : letterCount.entrySet()) {
                char letter = entry.getKey();
                int count = entry.getValue();

                int barHeight = (int) ((double) count / getMaxCount() * maxHeight);

                g.setColor(Color.BLUE);
                g.fillRect(x, getHeight() - barHeight - 50, barWidth, barHeight);

                g.setColor(Color.BLACK);
                g.drawRect(x, getHeight() - barHeight - 50, barWidth, barHeight);

                // Добавляем подпись для каждого столбца
                String label = String.format("%s: %d", letter, count);
                int labelX = x + barWidth / 2 - g.getFontMetrics().stringWidth(label) / 2;
                int labelY = getHeight() - barHeight - 55;
                g.drawString(label, labelX, labelY);

                x += barWidth + 10;
            }

            // Добавляем легенду
            int legendX = 30;
            int legendY = getHeight() - 20;
            for (Map.Entry<Character, Integer> entry : letterCount.entrySet()) {
                char letter = entry.getKey();
                g.drawString(String.valueOf(letter), legendX, legendY);
                legendX += barWidth + 10;
            }
        }
    }

    /**
     * Возвращает максимальное значение частоты в карте.
     *
     * @return Максимальное значение частоты.
     */
    private int getMaxCount() {
        int maxCount = 0;
        for (int count : letterCount.values()) {
            if (count > maxCount) {
                maxCount = count;
            }
        }
        return maxCount;
    }
}
