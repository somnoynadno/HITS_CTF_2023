package ru.greenpix.hedgehog.controller;

import io.swagger.v3.oas.annotations.Operation;
import io.swagger.v3.oas.annotations.Parameter;
import io.swagger.v3.oas.annotations.tags.Tag;
import lombok.RequiredArgsConstructor;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;
import ru.greenpix.hedgehog.dto.AnswerDto;
import ru.greenpix.hedgehog.service.JSCheckerService;

@RestController
@RequiredArgsConstructor
@RequestMapping("checker")
@Tag(name = "Чекер javascript кода")
public class JSCheckerController {

    private final JSCheckerService jsCheckerService;

    @PostMapping("js")
    @Operation(
            summary = "Проверить решение задачи 'Нечётность числа' на javascript",
            description = "Даны два числа 'a' и 'b', одно из которых чётное, а второе нечётное.\n" +
                    "\n" +
                    "Необходимо определить и вывести нечётное из них."
    )
    public AnswerDto run(
            @Parameter(example = "if (a % 2 == 0) {\n" +
                    "   a\n" +
                    "} else {\n" +
                    "   b\n" +
                    "}")
            @RequestBody
            String code
    ) {
        return jsCheckerService.execute(code);
    }

}
