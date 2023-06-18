import {useParams} from "react-router-dom";
import {useDispatch, useSelector} from "react-redux";
import {Container} from "react-bootstrap";
import {useEffect} from "react";
import {catalogThunkCreator} from "../Reducers/catalogReducer";
import 'bootstrap/dist/css/bootstrap.min.css';
import {DishItem} from "../Components/DishItem";


export function CatalogPage(){
    const params = useParams();
    const dispatcher = useDispatch();
    const state = useSelector((state) => state.catalogPage)
    const catalogArray = Object.values(state.data);
    useEffect(() => {
        dispatcher(catalogThunkCreator(params.id))
    }, )

    return (
        <Container className="main-container">
            {catalogArray.map((value, index) => {
                return <DishItem props={value} key={index}/>
            })}
        </Container>
    );
}