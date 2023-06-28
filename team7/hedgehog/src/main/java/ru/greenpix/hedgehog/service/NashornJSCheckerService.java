package ru.greenpix.hedgehog.service;

import lombok.RequiredArgsConstructor;
import org.springframework.stereotype.Service;
import ru.greenpix.hedgehog.dto.AnswerDto;
import ru.greenpix.hedgehog.dto.Verdict;
import ru.greenpix.hedgehog.model.Task;
import ru.greenpix.hedgehog.model.TaskTest;

import javax.script.Bindings;
import javax.script.ScriptEngine;
import javax.script.ScriptException;

@Service
@RequiredArgsConstructor
public class NashornJSCheckerService implements JSCheckerService {

    private final ScriptEngine engine;
    private final Task task;

    @Override
    public AnswerDto execute(String code) {
        for (int i = 0; i < task.getTests().size(); i++) {
            int testNumber = i + 1;
            TaskTest test = task.getTests().get(i);
            String input = test.getInput();
            String output = test.getOutput();

            try {
                engine.eval(input);
            }
            catch (ScriptException e) {
                e.printStackTrace();
                return new AnswerDto(Verdict.EPIC_FAIL, testNumber, null);
            }

            Object result;
            try {
                result = engine.eval(code);
            }
            catch (ScriptException e) {
                return new AnswerDto(Verdict.ERROR, testNumber, e.getMessage());
            }

            if (result == null) {
                return new AnswerDto(Verdict.EMPTY_ANSWER, testNumber, null);
            }

            if (!result.toString().equals(output)) {
                return new AnswerDto(Verdict.WRONG, testNumber, null);
            }
        }
        return new AnswerDto(Verdict.OK, null, null);
    }
}
