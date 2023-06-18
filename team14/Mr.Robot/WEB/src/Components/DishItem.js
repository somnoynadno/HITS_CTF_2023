import {Button, Card} from "react-bootstrap";


export function DishItem(props){

    return (
        <Card key={props.key} className="card">
            <Card.Body>
                <img className="img" src={props.props.pic}/>
                <p dangerouslySetInnerHTML={{__html: props.props.name}}></p>
                <div>
                    {props.props.description}
                </div>
                <div>
                    {props.props.weight}
                </div>
            </Card.Body>
            <Card.Header>{props.props.name}</Card.Header>
            <Card.Footer className="d-flex justify-content-center align-items-stretch">
                <Button>Добавить в корзину</Button>
                <div>
                    {props.props.price}
                </div>
            </Card.Footer>
        </Card>
    )
}