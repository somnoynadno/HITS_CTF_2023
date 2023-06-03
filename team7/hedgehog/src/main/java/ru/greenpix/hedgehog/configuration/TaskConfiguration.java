package ru.greenpix.hedgehog.configuration;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import ru.greenpix.hedgehog.model.Task;
import ru.greenpix.hedgehog.model.TaskTest;

import java.util.ArrayList;
import java.util.List;

@Configuration
public class TaskConfiguration {

    @Bean
    public Task exampleTask() {
        List<TaskTest> tests = new ArrayList<>();
        tests.add(new TaskTest("a=1;b=2", "1"));
        tests.add(new TaskTest("a=6;b=7", "7"));
        return new Task(tests);
    }
}
