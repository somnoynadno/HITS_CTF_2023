package com.echo.bugger.config;

import com.echo.bugger.filter.JwtFilter;
import lombok.RequiredArgsConstructor;
import org.springframework.context.annotation.Bean;
import org.springframework.context.annotation.Configuration;
import org.springframework.security.config.annotation.method.configuration.EnableGlobalMethodSecurity;
import org.springframework.security.config.annotation.web.builders.HttpSecurity;
import org.springframework.security.config.annotation.web.configuration.EnableWebSecurity;
import org.springframework.security.config.http.SessionCreationPolicy;
import org.springframework.security.web.SecurityFilterChain;
import org.springframework.security.web.authentication.UsernamePasswordAuthenticationFilter;

@Configuration
@EnableWebSecurity
@RequiredArgsConstructor
@EnableGlobalMethodSecurity(prePostEnabled = true)
public class SecurityConfig {

    private final JwtFilter jwtFilter;

    @Bean
    public SecurityFilterChain filterChain(HttpSecurity http) throws Exception {
        return http
                .httpBasic().disable()
                .csrf().disable()
                .sessionManagement().sessionCreationPolicy(SessionCreationPolicy.STATELESS)
                .and()
                .authorizeHttpRequests(
                        authz -> authz
                                .antMatchers("/me").authenticated()
                                .antMatchers("/users").authenticated()
                                .antMatchers("/sing-in").permitAll()
                                .antMatchers("/swagger-ui/**").permitAll()
                                .and()
                                .addFilterAfter(jwtFilter, UsernamePasswordAuthenticationFilter.class)
                ).build();
    }
}
//Bearer eyJhbGciOiJub25lIn0.eyJzdWIiOiJ0ZXN0ZXIiLCJleHAiOjE2ODUyNTE4MjcsImlkIjoiY2Q5NTcxOGUtOTMzNy00NjdlLTgwMjktYzAxZWM1YmI2MWU0In0K.SflKxwRJSMeKKF2QT4fwpMeJf36POk6yJV_adQssw5c