import { useEffect, useState } from "react"
import Categories from "../../components/Categories/Categories"
import CategoryService from "../../services/CategoryService"

function CategoriesPage()
{
    const [categories, setCategories] = useState<Category[]>([])

    useEffect(()=>{
        CategoryService.getCategories().then(res=>setCategories(res))
    },[])

    return <Categories categories={categories}/>

}

export default CategoriesPage