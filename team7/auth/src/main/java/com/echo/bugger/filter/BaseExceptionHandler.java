package com.echo.bugger.filter;

import com.echo.bugger.exception.CustomException;
import com.echo.bugger.exception.MessageDto;
import org.springframework.http.HttpHeaders;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.MethodArgumentNotValidException;
import org.springframework.web.bind.annotation.ControllerAdvice;
import org.springframework.web.bind.annotation.ExceptionHandler;
import org.springframework.web.context.request.WebRequest;
import org.springframework.web.servlet.mvc.method.annotation.ResponseEntityExceptionHandler;

import java.io.IOException;

@ControllerAdvice
public class BaseExceptionHandler extends ResponseEntityExceptionHandler {

    @ExceptionHandler(CustomException.class)
    private ResponseEntity<MessageDto> handleIllegalArgument(CustomException ex) throws IOException {
        MessageDto messageDto = new MessageDto(ex.getMessage());
        return new ResponseEntity<MessageDto>(messageDto, ex.getStatus());
    }

}
