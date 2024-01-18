import Image from 'next/image'

interface RubBotProps {
    title: string
    message: string  
    className?: string
}

const RubBotPopup: React.FC<RubBotProps> = ({  title, message }) => {
    return(
        <div className='w-full flex justify-center items-center'>
            <Image 
            src="/RubBot.svg"
            alt="RubBot image"
            className='w-3/12 mr-2' 
            width={100}
            height={100}
            priority
            />
            <div className='w-3/4 flex flex-col items-center justify-center bg-secondary-bg rounded-xl p-2'>
                <h2 className='font-bold text-primary-font mb-1'>{title}</h2>
                <span className='text-sm text-primary-font px-1'>{message}</span>
            </div>
        </div>
    )
}
export default RubBotPopup;