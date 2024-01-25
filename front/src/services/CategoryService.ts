import axios from "axios"

const url = "https://localhost:7161/allCategories"

async function getCategories() : Promise<Category[]>{
    const res = await axios.get(url)

    console.log(res.data)
    return res.data
}

const CategoryService = {
    getCategories,

}

export default CategoryService