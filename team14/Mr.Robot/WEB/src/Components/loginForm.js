import {useEffect, useState} from "react";
import {useDispatch, useSelector} from "react-redux";
import {checkPassThunkCreator} from "../Reducers/catalogReducer";
import {Button, Form} from "react-bootstrap";
import Container from "react-bootstrap/Container";


export function LoginForm(){
    const [password, setPassword] = useState('');
    const [warn, setWarn] = useState(true);
    const dispatcher = useDispatch();
    const state = useSelector((state) => state.catalogPage)

    const loginHandler = () => {
        let body = {
            "password": password
        }
        dispatcher(checkPassThunkCreator(body))
        setWarn(state.isLogged)
    }
    useEffect(()=> {
    }, [state])

    return(
        <>
            <Container className="mt-5 login-container">
                <h2>Зарегистрируйтесь</h2>
                <Form>
                    <label>Введите пароль</label>
                    <Form.Control
                        id="password"
                        className="mt-5"
                        value = {password}
                        onChange={(e)=> setPassword(e.target.value)}
                        placeholder="*****"
                    />
                    <Button className={`btn mt-5 ${warn?"btn-primary": "btn-danger"}`} onClick={loginHandler}>{warn?"Войти": "Попробуйте снова"}</Button>
                </Form>
            </Container>

        </>
    )
}