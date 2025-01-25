export default function Tab({ name, route }: { name: string; route: string }) {
  return (
    <>
      <li className="me-2">
        <a
          href={route}
          aria-current="page"
          className="inline-block pl-0.5 p-4 text-blue-600 bg-gray-100 rounded-t-lg active dark:bg-gray-800 dark:text-blue-500"
        >
          {name}
        </a>
      </li>
    </>
  );
}
