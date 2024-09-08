import java.util.*;
import java.util.stream.Collectors;

/**
 * Класс {@code TextAnalyzerHelper} предоставляет утилитарные методы для анализа текста и подсчета частоты букв.
 */
public class TextAnalyzerHelper {

    /**
     * Анализирует заданный текст и возвращает строковое представление частоты букв в алфавитном порядке.
     *
     * @param text Текст для анализа.
     * @return Строковое представление частоты букв в алфавитном порядке.
     */
    public static String analyzeAlphabeticalOrder(String text) {
        String language = detectLanguage(text);
        Map<Character, Integer> letterCount = countLetters(text, language);
        return buildResult(letterCount, language);
    }

    /**
     * Анализирует заданный текст и возвращает строковое представление частоты букв в обратном порядке.
     *
     * @param text Текст для анализа.
     * @return Строковое представление частоты букв в обратном порядке.
     */
    public static String analyzeReverseOrder(String text) {
        String language = detectLanguage(text);
        Map<Character, Integer> letterCount = countLetters(text, language);

        // Сортировка по убыванию частот
        List<Map.Entry<Character, Integer>> sortedEntries = letterCount.entrySet()
                .stream()
                .sorted(Collections.reverseOrder(Map.Entry.comparingByValue()))
                .collect(Collectors.toList());

        return buildResult(sortedEntries, language);
    }

    /**
     * Определяет язык текста (русский или английский) на основе используемого набора символов.
     *
     * @param text Текст для анализа.
     * @return Определенный язык ("ru" для русского, "en" для английского).
     */
    private static String detectLanguage(String text) {
        for (char ch : text.toCharArray()) {
            if (Character.UnicodeBlock.of(ch) == Character.UnicodeBlock.CYRILLIC) {
                return "ru";
            }
        }
        return "en";
    }

    /**
     * Подсчитывает количество вхождений букв в заданном тексте для конкретного языка.
     *
     * @param text     Текст для анализа.
     * @param language Язык текста ("ru" для русского, "en" для английского).
     * @return Карта, содержащая частоту букв.
     */
    public static Map<Character, Integer> countLetters(String text, String language) {
        Map<Character, Integer> letterCount = new HashMap<>();

        for (char ch : text.toCharArray()) {
            if (Character.isLetter(ch)) {
                if ((language.equals("ru") && Character.UnicodeBlock.of(ch) == Character.UnicodeBlock.CYRILLIC)
                        || (language.equals("en") && Character.UnicodeBlock.of(ch) == Character.UnicodeBlock.BASIC_LATIN)) {
                    letterCount.put(ch, letterCount.getOrDefault(ch, 0) + 1);
                }
            }
        }

        return letterCount;
    }

    /**
     * Подсчитывает количество вхождений букв в заданном тексте.
     *
     * @param text Текст для анализа.
     * @return Карта, содержащая частоту букв.
     */
    public static Map<Character, Integer> countLetters(String text) {
        Map<Character, Integer> letterCount = new HashMap<>();

        for (char ch : text.toCharArray()) {
            if (Character.isLetter(ch)) {
                letterCount.put(ch, letterCount.getOrDefault(ch, 0) + 1);
            }
        }

        return letterCount;
    }

    /**
     * Строит строковое представление частоты букв на основе предоставленной карты и языка.
     *
     * @param letterCount Карта, содержащая частоту букв.
     * @param language    Язык текста ("ru" для русского, "en" для английского).
     * @return Форматированное строковое представление частоты букв.
     */
    private static String buildResult(Map<Character, Integer> letterCount, String language) {
        StringBuilder result = new StringBuilder();

        char start, end;
        if (language.equals("ru")) {
            start = 'а';
            end = 'я';
        } else {
            start = 'a';
            end = 'z';
        }

        for (char ch = start; ch <= end; ch++) {
            result.append(ch).append(": ").append(letterCount.getOrDefault(ch, 0)).append("\n");
        }

        return result.toString();
    }

    /**
     * Строит строковое представление частоты букв на основе списка отсортированных записей и языка.
     *
     * @param sortedEntries Список отсортированных записей карты.
     * @param language      Язык текста ("ru" для русского, "en" для английского).
     * @return Форматированное строковое представление частоты букв.
     */
    private static String buildResult(List<Map.Entry<Character, Integer>> sortedEntries, String language) {
        StringBuilder result = new StringBuilder();

        for (Map.Entry<Character, Integer> entry : sortedEntries) {
            result.append(entry.getKey()).append(": ").append(entry.getValue()).append("\n");
        }

        return result.toString();
    }
}
