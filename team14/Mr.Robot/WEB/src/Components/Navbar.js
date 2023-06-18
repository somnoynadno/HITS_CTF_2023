import 'bootstrap/dist/css/bootstrap.min.css';
import React from "react";
import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';
import 'bootstrap/dist/css/bootstrap.min.css';
import {NavLink} from "react-router-dom";


export function NavBar(){
    return(
        <Navbar collapseOnSelect expand="lg" bg="dark" variant="dark" className="navbar">
            <Container className="d-flex align-items-baseline">
                <Navbar.Collapse id="responsive-navbar-nav">
                    <NavLink to="/" className="main-link">Ctf.Delivery</NavLink>
                    <Nav className="me-auto">
                        <NavLink to="/catalog/pizza/" className="link">Пицца</NavLink>
                        <NavLink to="/catalog/rolls/" className="link">Роллы</NavLink>
                        <NavLink to="/catalog/drinks/" className="link">Напитки</NavLink>
                    </Nav>
                    <Nav>
                        <NavLink to="/delivery-info/" className="link">Условия доставки</NavLink>
                        <NavLink to="/add/dish" className="link">Добавить блюдо</NavLink>
                    </Nav>
                </Navbar.Collapse>
            </Container>

        </Navbar>
    )
}