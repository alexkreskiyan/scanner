create table orders (
    id uuid not null primary key,
    status smallint not null,
    document_types text[] not null,
    files uuid[] not null
);

create table documents (
    id uuid not null primary key,
    order_id uuid not null,
    type text not null,
    constraint fk_documents_orders_order_id foreign KEY (order_id) references orders (id) on delete RESTRICT
);

create table document_fields (
    id uuid not null primary key,
    document_id uuid not null,
    type text not null,
    value text not null,
    constraint fk_document_fields_documents_document_id foreign KEY (document_id) references documents (id) on delete RESTRICT
);

create table document_pages (
    id uuid not null primary key,
    document_id uuid not null,
    type text not null,
    file_id uuid not null,
    constraint fk_document_pages_documents_document_id foreign KEY (document_id) references documents (id) on delete RESTRICT
);
