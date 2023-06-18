import {useSelector} from "react-redux";
import {useEffect} from "react";
import 'bootstrap/dist/css/bootstrap.min.css';
import {LoginForm} from "../Components/loginForm";
import {AddDishForm} from "../Components/addDishForm";
import Container from "react-bootstrap/Container";


export function AddDishPage(){
    const state = useSelector((state) => state.catalogPage)

    useEffect(() => {

    }, [state])

    return (
        <>
            <Container>
                {state.isLogged?<AddDishForm/>:<LoginForm/>}
            </Container>
        </>
    );
}