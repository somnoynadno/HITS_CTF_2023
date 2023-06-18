import {Container, Nav} from "react-bootstrap";

/*{props.basket.count}*/
export function Basket(props) {
    return (
        <Container className="basket-icon d-flex">
            <Nav>
                <label>Корзина</label>
            </Nav>
            <div className="basket-count">3 - placeholder</div>
        </Container>
    )
}