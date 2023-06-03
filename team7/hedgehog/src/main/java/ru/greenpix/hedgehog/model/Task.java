package ru.greenpix.hedgehog.model;

import lombok.Data;

import java.util.List;

@Data
public class Task {

    private final List<TaskTest> tests;

}
