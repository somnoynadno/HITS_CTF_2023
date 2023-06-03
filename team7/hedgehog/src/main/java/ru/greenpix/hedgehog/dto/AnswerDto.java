package ru.greenpix.hedgehog.dto;

import lombok.Data;

@Data
public class AnswerDto {

    private final Verdict verdict;
    private final Integer testNumber;
    private final String error;

}
