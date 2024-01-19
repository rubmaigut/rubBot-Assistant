import Link from "next/link";
import { FontAwesomeIcon } from "@fortawesome/react-fontawesome";
import {
  faCommentMedical,
  faChartSimple,
  faClipboardList,
} from "@fortawesome/free-solid-svg-icons";

interface FooterProps {
  className?: string;
}

const Footer: React.FC<FooterProps> = () => {
  return (
    <footer className="w-full bg-white h-16 flex items-center justify-between px-8 py-4 rounded-xl">
        <div className="flex justify-center">
          <FontAwesomeIcon
            icon={faClipboardList}
            className="w-8"
            style={{ color: "#482A25" }}
          />
        </div>
      <Link href="/chat">
        <div className="flex justify-center">
          <FontAwesomeIcon
            icon={faCommentMedical}
            className="w-8"
            style={{ color: "#482A25" }}
          />
        </div>
      </Link>
        <div className="flex justify-center">
          <FontAwesomeIcon
            icon={faChartSimple}
            className="w-8"
            style={{ color: "#FAAB4E" }}
          />
        </div>
    </footer>
  );
};
export default Footer;
