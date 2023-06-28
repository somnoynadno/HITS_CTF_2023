package ru.greenpix.hedgehog.configuration;

import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;

import javax.script.ScriptEngine;
import javax.script.ScriptEngineManager;

@Configuration
public class ScriptEngineConfiguration {

    @Bean
    public ScriptEngine scriptEngine() {
        return new ScriptEngineManager().getEngineByName("nashorn");
    }
}
