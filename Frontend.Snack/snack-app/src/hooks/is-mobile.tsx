import { useState } from "react";
import resolveConfig from 'tailwindcss/resolveConfig'
import tailwindConfig from '../../tailwind.config.js'

const fullConfig = resolveConfig(tailwindConfig)
const getIsMobile = () => window.innerWidth <= 


export default function useIsMobile(){
    const [isMobile, setIsMobile] = useState()
}