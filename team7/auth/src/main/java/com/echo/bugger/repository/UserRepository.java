package com.echo.bugger.repository;

import com.echo.bugger.model.User;
import org.springframework.beans.factory.annotation.Value;
import org.springframework.stereotype.Repository;
import org.springframework.stereotype.Service;

import javax.annotation.PostConstruct;
import java.util.ArrayList;
import java.util.List;
import java.util.UUID;

@Service
public class UserRepository {

    private List<User> users;
    @Value("${flag.flag}")
    private String flag;

    @PostConstruct
    public void setUp() {
        users = new ArrayList<>();
        List<String> logins = List.of(
                "tester",
                "hacker",
                "power",
                "list",
                "admin",
                "bad_hacker",
                "attacker"
        );
        List<UUID> uuid = List.of(
            UUID.fromString("eb90e1b0-e7a8-4404-aabb-ff5fa6420af1"),
            UUID.fromString("601c28a1-47dc-4f32-b826-f78b7519ac39"),
            UUID.fromString("f3063063-6653-4870-9834-311371d9e769"),
            UUID.fromString("49f69013-16f9-4bda-8906-d2c1f9343973"),
            UUID.fromString("cd95718e-9337-467e-8029-c01ec5bb61e4"),
            UUID.fromString("5b86a0ce-377e-4624-a1c3-abcd895d0d26"),
            UUID.fromString("64ad611c-9888-45cf-b4a9-d3f280f91fd7")
        );
        List<String> passwords = List.of(
                "123qwerty",
                "qweesadsa12412",
                "qwe123214",
                "413rdqfawsc",
                "a31sad2414",
                "21asd3213",
                "212321asd"
        );

        List<List<String>> lists = List.of(
                List.of("my_pass", "maybe_admin_have_flag?", "U"),
                List.of("teasfs", "age"),
                List.of("chainman", "anime"),
                List.of("top", "bottom"),
                List.of("flag", "flag", flag),
                List.of("bad"),
                List.of("hack")
        );

        for(int i = 0; i < 7; i++) {
            User user = new User();
            user.setId(uuid.get(i));
            user.setLogin(logins.get(i));
            user.setPassword(passwords.get(i));
            user.setPasswords(lists.get(i));
            users.add(user);
        }
    }

    public List<User> getAll() {
        return users;
    }

    public User getById(UUID id) {

        for (User user : users)
        {
            if(user.getId().equals(id)) {
                return user;
            }
        }
        return null;
    }

    public User getByLogin(String login) {

        for (User user : users)
        {
            if(user.getLogin().equals(login)) {
                return user;
            }
        }
        return null;
    }
}
