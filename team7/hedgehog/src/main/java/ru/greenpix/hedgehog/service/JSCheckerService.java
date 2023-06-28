package ru.greenpix.hedgehog.service;

import ru.greenpix.hedgehog.dto.AnswerDto;

public interface JSCheckerService {

    AnswerDto execute(String code);

}
