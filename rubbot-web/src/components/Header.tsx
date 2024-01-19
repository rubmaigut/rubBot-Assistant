import Image from 'next/image'
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import { faUser } from "@fortawesome/free-solid-svg-icons";

interface HeaderProps {
    logo: string
    className?: string
}

const Header: React.FC<HeaderProps> = ({ logo, className }) => {
    return(
        <header className='w-full h-24 flex items-center justify-between '>
            <div className='w-2/4 '>
            <Image 
            src={logo}
            alt={logo}
            className={className}
            width={160}
            height={20}
            priority
            />
            </div>
            <div className='w-12 flex justify-end mr-4'>
            <FontAwesomeIcon
            icon={faUser}
            className="w-6"
            style={{ color: "#482A25" }}
          />
            </div>
        </header>
    )
}
export default Header;