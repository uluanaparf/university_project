import javax.swing.text.DefaultHighlighter;
import javax.swing.*;
import java.awt.*;

/**
 * Класс SearchFunction предоставляет функциональность выделения текста в JTextArea.
 */
public class SearchFunction extends JFrame{

    private JTextArea textArea;

    /**
     * Конструктор класса SearchFunction.
     *
     * @param textArea JTextArea, в котором будет производиться поиск и выделение текста.
     */
    public SearchFunction(JTextArea textArea) {
        this.textArea = textArea;
    }

    /**
     * Выделяет все вхождения указанного текста в JTextArea цветом.
     *
     * @param searchTerm Текст для поиска и выделения.
     */
    public void highlightText(String searchTerm) {
        if (searchTerm.isEmpty()) {
            clearHighlights();
            return;
        }

        String text = textArea.getText();
        clearHighlights();

        int index = text.indexOf(searchTerm);
        while (index >= 0) {
            try {
                textArea.getHighlighter().addHighlight(index, index + searchTerm.length(),
                        new DefaultHighlighter.DefaultHighlightPainter(Color.YELLOW));
                index = text.indexOf(searchTerm, index + 1);
            } catch (Exception e) {
                e.printStackTrace();
            }
        }
    }

    /**
     * Очищает все выделения в JTextArea.
     */
    private void clearHighlights() {
        textArea.getHighlighter().removeAllHighlights();
    }
}
