import {useEffect, useState} from "react";
import {useDispatch, useSelector} from "react-redux";
import {addDishThunkCreator} from "../Reducers/catalogReducer";
import {Button, ButtonGroup, Form, FormLabel} from "react-bootstrap";
import {NavLink} from "react-router-dom";


export function AddDishForm(){
    const [category, setCategory] = useState('');
    const [name, setName] = useState('');
    const [description, setDescription] = useState('');
    const [price, setPrice] = useState(0);
    const [weight, setWeight] = useState(0);
    const [img, setImg] = useState('');
    const [warn, setWarn] = useState(true);
    const [done, setdone] = useState(false);
    const dispatcher = useDispatch();
    const state = useSelector((state) => state.catalogPage)

    useEffect(()=>{
    }, [state, category])

    const addHandler = () => {
        const body = {
            "name": name,
            "description": description,
            "price": price,
            "weight": weight,
            "pic": img
        }
        dispatcher(addDishThunkCreator(body, category))
        setWarn(state.dishAdding)
        if(warn === true){
            setdone(true)
        }
    }


    return(
        <>
            <Form className="container mt-5">
                <FormLabel className="form-label" htmlFor="name">Название</FormLabel>
                <Form.Control
                    id="name"
                    value = {name}
                    onChange={(e)=> setName(e.target.value)}
                    placeholder="Название"
                />
                <FormLabel className="form-label" htmlFor="description">Описание</FormLabel>
                <Form.Control
                    id="description"
                    value = {description}
                    onChange={(e)=> setDescription(e.target.value)}
                    placeholder="Описание"
                />
                <FormLabel className="form-label" htmlFor="price">Цена</FormLabel>
                <Form.Control
                    id="price"
                    type="number"
                    value = {price}
                    onChange={(e)=> setPrice(e.target.value)}
                    placeholder="0"
                />
                <FormLabel className="form-label" htmlFor="weight">Вес</FormLabel>
                <Form.Control
                    id="weight"
                    type="number"
                    value = {weight}
                    onChange={(e)=> setWeight(e.target.value)}
                    placeholder="0 грамм"
                />
                <FormLabel className="form-label" htmlFor="img">Ссылка на картинку</FormLabel>
                <Form.Control
                    id="img"
                    type="text"
                    value = {img}
                    onChange={(e)=> setImg(e.target.value)}
                    placeholder="https://..."
                />
                <ButtonGroup className='d-flex p-5'>
                    <button type="button" className={`m-2 btn ${category === "pizza"?" btn-primary": " btn-outline-primary"}`} onClick={() => setCategory("pizza")}>Пицца</button>
                    <button type="button" className={`m-2 btn ${category === "drink"?" btn-primary": " btn-outline-primary"}`} onClick={() => setCategory("drink")}>Напитки</button>
                    <button type="button" className={`m-2 btn ${category === "roll"?" btn-primary": " btn-outline-primary"}`} onClick={() => setCategory("roll")}>Роллы</button>
                </ButtonGroup>
                {done?<NavLink to="/catalog/pizza">К пиццам</NavLink>:
                <Button className={`btn ${warn?"btn-primary": "btn-danger"}`} onClick={addHandler}>{warn?"Добавить": "Попробуйте снова"}</Button>}
            </Form>
        </>
    )
}